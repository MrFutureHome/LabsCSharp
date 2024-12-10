using SQLCarsApp.carsSQLDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;


namespace SQLCarsApp
{
    public partial class MainForm : Form
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings
            ["SQLCarsApp.Properties.Settings.carsSQLConnectionString"].ConnectionString;
        public MainForm()
        {
            InitializeComponent();
            RefreshTables();
            dataSettingsInitialize();
            userDataInitialize();
            carSaleSettingsInitialize();
            userSettingsInitialize();
        }
        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        //функция для обновления таблиц
        public void RefreshTables()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable2TableAdapter.GetData();
            dataGridView1.Update();
            dataGridView1.Refresh();
            ((System.Data.DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $@"status = 'Забронировано ({DataBank.client_ID})' OR 
                status = 'В продаже' OR status = 'В обработке ({DataBank.client_ID})' OR owner = '{DataBank.client_ID}' OR 
                status = 'Продано ({DataBank.client_ID})'";

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dataTable1TableAdapter.GetData();
            dataGridView2.Update();
            dataGridView2.Refresh();
        }

        //функция для генерации произвольного VIN номера
        public static string GenerateRandomVin()
        {
            Random random2 = new Random(Guid.NewGuid().GetHashCode());
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] vin = new char[17];

            // Первые 3 символа - WMI (World Manufacturer Identifier)
            for (int i = 0; i < 3; i++)
            {
                vin[i] = chars[random2.Next(chars.Length)];
            }

            // Следующие 5 символов - VDS (Vehicle Descriptor Section)
            for (int i = 3; i < 8; i++)
            {
                vin[i] = chars[random2.Next(chars.Length)];
            }

            // 9-17 символы - VIS (Vehicle Identifier Section)
            for (int i = 8; i < 17; i++)
            {
                vin[i] = chars[random2.Next(chars.Length)];
            }

            return new string(vin);
        }

        private void userDataInitialize()
        {
            userData_selectUserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            userData_selectUserComboBox.Items.Clear();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getAllUsers = "select user_name, login from users";

                using (SqlCommand cmd = new SqlCommand(getAllUsers, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string name = $"{reader["user_name"].ToString()} ({reader["login"].ToString()})";
                                userData_selectUserComboBox.Items.Add(name);
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
        }

        private void userSettingsInitialize()
        {
            settings_nameTextBox.Text = DataBank.client_name;

            if (DataBank.check_for_director == false)
            {
                groupBox4.Enabled = false;
            }
            if (DataBank.check_for_director == false && DataBank.check_for_sysadmin == false)
            {
                tabControl1.TabPages.RemoveAt(3);
            }
            if (DataBank.check_for_manager == false && DataBank.check_for_consult == false)
            {
                tabControl1.TabPages.RemoveAt(2);
            }
            tabControl1.TabPages.RemoveAt(4);
        }

        private void dataSettingsInitialize()
        {
            CarsData_brandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CarsData_modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CarsData_combosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            CarsData_brandComboBox.Items.Clear();
            CarsData_modelComboBox.Items.Clear();
            CarsData_combosComboBox.Items.Clear();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getBrandsQuery = "select brand_name from brand";
                string getModelsQuery = "select model_name from model";
                string getCombosQuery = "select brandModel.id as combo_id, brand_name, model_name from brandModel " +
                    "inner join brand on brand.id = id_brand " +
                    "inner join model on model.id = id_model";

                using (SqlCommand cmd = new SqlCommand(getBrandsQuery, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string brand = reader.GetString(0);
                                CarsData_brandComboBox.Items.Add(brand);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getModelsQuery, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string model = reader.GetString(0);
                                CarsData_modelComboBox.Items.Add(model);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getCombosQuery, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string combo = "(" + reader["combo_id"].ToString() + ") " + reader["brand_name"].ToString() + " " + reader["model_name"].ToString();
                                CarsData_combosComboBox.Items.Add(combo);
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
        }

        private void carSaleSettingsInitialize()
        {
            sellCarColorComboBox.Items.Clear();
            sellCarBrandComboBox.Items.Clear();
            sellCarDriveComboBox.Items.Clear();
            sellCarEngineComboBox.Items.Clear();
            sellCarGearComboBox.Items.Clear();
            sellCarGearComboBox.Items.Clear();
            sellCarBodyComboBox.Items.Clear();

            sellCarColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sellCarBrandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            SellCarModelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sellCarDriveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sellCarEngineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sellCarGearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            sellCarBodyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getColors = "select color_name from colors";
                string getBrands = "select brand_name from brand";
                string getDrive = "select drive_type from driveType";
                string getEngines = "select engine_type from engineType";
                string getGears = "select gear_type from gearType";
                string getBodies = "select type from bodyTypes";

                using (SqlCommand cmd = new SqlCommand(getColors, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                sellCarColorComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getBrands, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                sellCarBrandComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getDrive, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                sellCarDriveComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getEngines, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                sellCarEngineComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getGears, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                sellCarGearComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getBodies, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                sellCarBodyComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
            }
        } 

        private void refreshCombosComboBox()
        {
            CarsData_combosComboBox.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getCombosQuery = "select brandModel.id as combo_id, brand_name, model_name from brandModel " +
                    "inner join brand on brand.id = id_brand " +
                    "inner join model on model.id = id_model";

                using (SqlCommand cmd = new SqlCommand(getCombosQuery, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string combo = "(" + reader["combo_id"].ToString() + ") " + reader["brand_name"].ToString() + " " + reader["model_name"].ToString();
                                CarsData_combosComboBox.Items.Add(combo);
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void CarsData_addBrandButton_Click(object sender, EventArgs e)
        {
            if (CarsData_addBrandTextBox.Text == "")
            {
                MessageBox.Show("Введите текст!");
            }
            else
            {
                string phrase = CarsData_addBrandTextBox.Text.ToString();
                string[] words = phrase.Split(';');
                int count = 0;

                foreach (var word in words)
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();
                        string CheckForDublicatesQuery = @"select * from brand where brand_name = @brand_name";
                        string query = @"insert into brand (brand_name, concern_id) 
                        values (@brand_name, @concern_id)";

                        using (SqlCommand cmdCheck = new SqlCommand(CheckForDublicatesQuery, con))
                        {
                            cmdCheck.Parameters.Clear();
                            cmdCheck.Parameters.AddWithValue("@brand_name", word.ToString());

                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    reader.Close();
                                    using (SqlCommand cmd = new SqlCommand(query, con))
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@brand_name", word.ToString());
                                        cmd.Parameters.AddWithValue("@concern_id", 1);

                                        cmd.ExecuteNonQuery();
                                        count++;
                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                    
                }
                MessageBox.Show($"Записей внесено: {count}");
                dataSettingsInitialize();
            }
            
        }

        private void CarsData_addModelButton_Click(object sender, EventArgs e)
        {
            if (CarsData_addModelsTextBox.Text == "")
            {
                MessageBox.Show("Введите текст!");
            }
            else
            {
                string phrase = CarsData_addModelsTextBox.Text.ToString();
                string[] words = phrase.Split(';');
                int count = 0;

                foreach (var word in words)
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();
                        string CheckForDublicatesQuery = @"select * from model where model_name = @model_name";
                        string query = @"insert into model (model_name) values (@model_name)";

                        using (SqlCommand cmdCheck = new SqlCommand(CheckForDublicatesQuery, con))
                        {
                            cmdCheck.Parameters.Clear();
                            cmdCheck.Parameters.AddWithValue("@model_name", word.ToString());

                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    if (reader.Read())
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    reader.Close();
                                    using (SqlCommand cmd = new SqlCommand(query, con))
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@model_name", word.ToString());
                                        cmd.ExecuteNonQuery();
                                        count++;
                                    }
                                }
                            }
                        }
                        con.Close();
                    }
                }
                MessageBox.Show($"Записей внесено: {count}");
                dataSettingsInitialize();
            }
        }

        private void CarsData_createCombinationButton_Click(object sender, EventArgs e)
        {
            //int idOfBrand;
            //int idOfModel;

            using (SqlConnection con = new SqlConnection(ConnectionString)) 
            {
                con.Open();
                int idOfBrand = 0;
                int idOfModel = 0;

                string getBrandIdQuery = "select brand.id from brand where brand_name = @brand_name";
                string getModelIdQuery = "select model.id from model where model_name = @model_name";
                string checkForExistingCombos = "select * from brandModel where id_brand = @id_brand and id_model = @id_model";
                string insertComboQuery = @"insert into brandModel (id_brand, id_model) 
                        values (@id_brand, @id_model)";
                

                using (SqlCommand cmd = new SqlCommand(getBrandIdQuery, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@brand_name", CarsData_brandComboBox.SelectedItem.ToString());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                idOfBrand = reader.GetInt32(0);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(getModelIdQuery, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@model_name", CarsData_modelComboBox.SelectedItem.ToString());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                idOfModel = reader.GetInt32(0);
                            }
                        }
                        reader.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(checkForExistingCombos, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id_brand", idOfBrand);
                    cmd.Parameters.AddWithValue("@id_model", idOfModel);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Такое сочетание уже существует!");
                            }
                        }
                        else
                        {
                            reader.Close();
                            using (SqlCommand cmd2 = new SqlCommand(insertComboQuery, con))
                            {
                                cmd2.Parameters.Clear();
                                cmd2.Parameters.AddWithValue("@id_brand", idOfBrand);
                                cmd2.Parameters.AddWithValue("@id_model", idOfModel);
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Успешно!");
                            }
                        }
                    }
                }

                con.Close();
                refreshCombosComboBox();
            }
        }

        private void userData_selectUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            userData_directorCheckBox.Checked = false;
            userData_sysadminCheckBox.Checked = false;
            userData_consultCheckBox.Checked = false;
            userData_managerCheckBox.Checked = false;
            userData_clientCheckBox.Checked = false;

            DataBank.selectedUser_check_for_director = false;
            DataBank.selectedUser_check_for_sysadmin = false;
            DataBank.selectedUser_check_for_consult = false;
            DataBank.selectedUser_check_for_manager = false;
            DataBank.selectedUser_check_for_client = false;
           

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getUserId = "select id, user_name, login from users where login = @login";
                string getUserRoles = "select role_id from userRole where user_id = @user_id";
                string selectedUserLogin = "";

                var fullstr = userData_selectUserComboBox.SelectedItem.ToString();
                string[] strs = fullstr.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in strs)
                {
                    selectedUserLogin = str;
                }

                using (SqlCommand cmd = new SqlCommand(getUserId, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@login", selectedUserLogin);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                DataBank.selectedUser_id = Convert.ToInt32(reader["id"]);
                                userData_nameTextBox.Text = reader["user_name"].ToString();
                                userData_loginTextBox.Text = reader["login"].ToString();
                            }
                        }
                        reader.Close();
                    }
                }

                using (SqlCommand cmd = new SqlCommand(getUserRoles, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@user_id", DataBank.selectedUser_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Convert.ToInt32(reader["role_id"]) == 1)
                                {
                                    DataBank.selectedUser_check_for_director = true;
                                    userData_directorCheckBox.Checked = true;
                                }
                                if (Convert.ToInt32(reader["role_id"]) == 2)
                                {
                                    DataBank.selectedUser_check_for_sysadmin = true;
                                    userData_sysadminCheckBox.Checked = true;
                                }
                                if (Convert.ToInt32(reader["role_id"]) == 3)
                                {
                                    DataBank.selectedUser_check_for_consult = true;
                                    userData_consultCheckBox.Checked = true;
                                }
                                if (Convert.ToInt32(reader["role_id"]) == 4)
                                {
                                    DataBank.selectedUser_check_for_manager = true;
                                    userData_managerCheckBox.Checked = true;
                                }
                                if (Convert.ToInt32(reader["role_id"]) == 5)
                                {
                                    DataBank.selectedUser_check_for_client = true;
                                    userData_clientCheckBox.Checked = true;
                                }
                            }
                        }
                    }
                }
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            carNameLabel.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            carModelLabel.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            carColorLabel.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            carYearLabel.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            carVINLabel.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getSelectedCarDataQuery = "select VIN from car where VIN = @VIN";

                using (SqlCommand cmd = new SqlCommand(getSelectedCarDataQuery, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VIN", dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                //DataBank.selectedCarID = Convert.ToInt32(reader["car_id"]);
                                DataBank.selectedCarVIN = reader["VIN"].ToString();
                            }
                        }
                    }
                }
                    
            }
        }

        private void debug_addRandomCarsButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(debug_carsCountTextBox.Text, out int value))
            {
           
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string generateRandomCarQuery = $@"insert into car (VIN, idBrandModel, color, year_of_manufacture, delivery_date, status, 
                        body_type, gearType, driveType, engineType, owner, price) 
                        values (@VIN, (SELECT TOP 1 id FROM brandModel ORDER BY NEWID()), @color, @year_of_manufacture, @delivery_date, @status, 
                        @body_type, @gearType, @driveType, @engineType, @owner, @price)";
                    con.Open();
                    
                    for (int i = 0; i < value; i++)
                    {
                        string vin = "";
                        vin = GenerateRandomVin();
                        
                        using (SqlCommand cmd = new SqlCommand(generateRandomCarQuery, con))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@VIN", vin);
                            cmd.Parameters.AddWithValue("@color", rnd.Next(1, 9));
                            cmd.Parameters.AddWithValue("@year_of_manufacture", rnd.Next(2014, 2020));
                            cmd.Parameters.AddWithValue("@delivery_date", DateTime.Today);
                            cmd.Parameters.AddWithValue("@status", "В продаже");
                            cmd.Parameters.AddWithValue("@body_type", rnd.Next(1, 15));
                            cmd.Parameters.AddWithValue("@gearType", rnd.Next(1, 5));
                            cmd.Parameters.AddWithValue("@driveType", rnd.Next(1, 3));
                            cmd.Parameters.AddWithValue("@engineType", rnd.Next(1, 4));
                            cmd.Parameters.AddWithValue("@owner", rnd.Next(1, 4));
                            cmd.Parameters.AddWithValue("@price", rnd.Next(1000000, 2000000));

                            cmd.ExecuteNonQuery();
                        }
                            
                    }
                    MessageBox.Show("Генерация выполнена!");
                    
                    con.Close();
                    RefreshTables();
                }
            }
            else
            {
                MessageBox.Show("Введите число!");
            }
        }

        private void makeOrderButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = $@"update car set status = 'Забронировано ({DataBank.client_ID})' where VIN = @VIN; 
                    insert into [order] (VIN, buyer_id, seller_id, order_date) values 
                    (@VIN, @buyer_id, (select owner from car where VIN = @VIN), @order_date)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VIN", DataBank.selectedCarVIN.ToString());
                    cmd.Parameters.AddWithValue("@buyer_id", DataBank.client_ID);
                    cmd.Parameters.AddWithValue("@order_date", DateTime.Today);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                RefreshTables();
                MessageBox.Show("Успешно!");
            }
        }

        private void userData_UpdateUserButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                int role_idValue = 0;

                string insertQuery = "insert into userRole (user_id, role_id) values (@user_id, @role_id)";
                string deleteQuery = "delete from userRole where user_id = @user_id and role_id = @role_id";
                string updateQuery = "update users set user_name = @user_name, login = @login where id = @id";

                void executeInsert()
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@role_id", role_idValue);
                        cmd.Parameters.AddWithValue("@user_id", DataBank.selectedUser_id);
                        cmd.ExecuteNonQuery();
                    }
                }
                
                void executeDelete()
                {
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@role_id", role_idValue);
                        cmd.Parameters.AddWithValue("@user_id", DataBank.selectedUser_id);
                        cmd.ExecuteNonQuery();
                    }
                }

                void executeUpdate()
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@user_name", userData_nameTextBox.Text);
                        cmd.Parameters.AddWithValue("@login", userData_loginTextBox.Text);
                        cmd.Parameters.AddWithValue("@id", DataBank.selectedUser_id);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (userData_directorCheckBox.Checked && DataBank.selectedUser_check_for_director == false)
                {
                    role_idValue = 1;
                    executeInsert();
                    DataBank.selectedUser_check_for_director = true;
                }
                else if (!userData_directorCheckBox.Checked && DataBank.selectedUser_check_for_director == true)
                {
                    role_idValue = 1;
                    executeDelete();
                    DataBank.selectedUser_check_for_director = false;
                }

                if (userData_sysadminCheckBox.Checked && DataBank.selectedUser_check_for_sysadmin == false)
                {
                    role_idValue = 2;
                    executeInsert();
                    DataBank.selectedUser_check_for_sysadmin = true;
                }
                else if (!userData_sysadminCheckBox.Checked && DataBank.selectedUser_check_for_sysadmin == true)
                {
                    role_idValue = 2;
                    executeDelete();
                    DataBank.selectedUser_check_for_sysadmin = false;
                }

                if (userData_consultCheckBox.Checked && DataBank.selectedUser_check_for_consult == false)
                {
                    role_idValue = 3;
                    executeInsert();
                    DataBank.selectedUser_check_for_consult = true;
                }
                else if (!userData_consultCheckBox.Checked && DataBank.selectedUser_check_for_consult == true)
                {
                    role_idValue = 3;
                    executeDelete();
                    DataBank.selectedUser_check_for_consult = false;
                }

                if (userData_managerCheckBox.Checked && DataBank.selectedUser_check_for_manager == false)
                {
                    role_idValue = 4;
                    executeInsert();
                    DataBank.selectedUser_check_for_manager = true;
                }
                else if (!userData_managerCheckBox.Checked && DataBank.selectedUser_check_for_manager == true)
                {
                    role_idValue = 4;
                    executeDelete();
                    DataBank.selectedUser_check_for_manager = false;
                }

                if (userData_clientCheckBox.Checked && DataBank.selectedUser_check_for_client == false)
                {
                    role_idValue = 5;
                    executeInsert();
                    DataBank.selectedUser_check_for_client = true;
                }
                else if (!userData_clientCheckBox.Checked && DataBank.selectedUser_check_for_client == true)
                {
                    role_idValue = 5;
                    executeDelete();
                    DataBank.selectedUser_check_for_client = false;
                }

                executeUpdate();

                con.Close();
                MessageBox.Show("Изменения успешно внесены!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ((System.Data.DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $@"status = 'Забронировано ({DataBank.client_ID})'  
                OR status = 'В обработке ({DataBank.client_ID})' OR owner = '{DataBank.client_ID}' OR status = 'Продано ({DataBank.client_ID})'";
            }
            else
            {
                ((System.Data.DataTable)dataGridView1.DataSource).DefaultView.RowFilter = $@"status = 'Забронировано ({DataBank.client_ID})'  
                OR status = 'В обработке ({DataBank.client_ID})' OR status = 'В продаже'";
            }
        }

        private void sellCarButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString)) 
            {
                con.Open();
                string query = @"insert into car (VIN, idBrandModel, color, year_of_manufacture, delivery_date, status, 
                    body_type, gearType, driveType, engineType, owner, price)
                    values (@VIN, (select id from brandModel where id_brand = (select id from brand where brand_name = @brand_name) 
                    and id_model = (select id from model where model_name = @model_name)), 
                    (select id from colors where color_name = @color_name), @year_of_manufacture, @delivery_date, @status, 
                    (select id from bodyTypes where type = @type), (select id from gearType where gear_type = @gear_type), 
                    (select id from driveType where drive_type = @drive_type), (select id from engineType where engine_type = @engine_type), 
                    @owner, @price)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VIN", sellCarVINTextBox.Text);
                    cmd.Parameters.AddWithValue("@brand_name", sellCarBrandComboBox.Text);
                    cmd.Parameters.AddWithValue("@model_name", SellCarModelComboBox.Text);
                    cmd.Parameters.AddWithValue("@color_name", sellCarColorComboBox.Text);
                    cmd.Parameters.AddWithValue("@year_of_manufacture", sellCarYearTextBox.Text);
                    cmd.Parameters.AddWithValue("@delivery_date", DateTime.Today);
                    cmd.Parameters.AddWithValue("@status", "В продаже");
                    cmd.Parameters.AddWithValue("@type", sellCarBodyComboBox.Text);
                    cmd.Parameters.AddWithValue("@gear_type", sellCarGearComboBox.Text);
                    cmd.Parameters.AddWithValue("@drive_type", sellCarDriveComboBox.Text);
                    cmd.Parameters.AddWithValue("@engine_type", sellCarEngineComboBox.Text);
                    cmd.Parameters.AddWithValue("@owner", DataBank.client_ID);
                    cmd.Parameters.AddWithValue("@price", sellCarPriceTextBox.Text);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }
            MessageBox.Show("Успешно!");
            RefreshTables();
        }

        private void sellCarBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SellCarModelComboBox.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = @"select model_name from brandModel 
                    inner join model on brandModel.id_model = model.id 
                    inner join brand on brandModel.id_brand = brand.id 
                    where brand_name = @brand_name";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@brand_name", sellCarBrandComboBox.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string data = reader.GetString(0);
                                SellCarModelComboBox.Items.Add(data);
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
        }

        private void settings_ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (settings_OldPasswordTextBox.Text == "" || settings_NewPasswordTextBox.Text == "" || settings_NewPasswordConfirmTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionString)) 
                {
                    con.Open();
                    string query = @"update users 
                        set password = @password where id = @id";

                    using (SqlCommand cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@password", GetHash(settings_NewPasswordTextBox.Text));
                        cmd.Parameters.AddWithValue("@id", DataBank.client_ID);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Успешно!");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string getSelectedCarDataQuery = @"select VIN, status, brand.brand_name as brand, model.model_name as model, 
                    colors.color_name as color, engineType.engine_type as engine, driveType.drive_type as drive, 
                    gearType.gear_type as gear, bodyTypes.type as body, car.year_of_manufacture as year, price from car 
                    inner join brandModel on car.idBrandModel = brandModel.id
                    inner join brand on brandModel.id_brand = brand.id
                    inner join model on brandModel.id_model = model.id
                    inner join engineType on car.engineType = engineType.id
                    inner join driveType on car.driveType = driveType.id
                    inner join gearType on car.gearType = gearType.id
                    inner join bodyTypes on car.body_type = bodyTypes.id
                    inner join colors on car.color = colors.id
                    where VIN = @VIN";

                string getNames = @"select user_name from users where id = @id";

                string selectedUserID = "";

                using (SqlCommand cmd = new SqlCommand(getSelectedCarDataQuery, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VIN", dataGridView2[1, dataGridView1.CurrentRow.Index].Value.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                DataBank.orders_selectedCarVIN = reader["VIN"].ToString();

                                orders_carNameLabel.Text = reader["brand"].ToString();
                                orders_carModelLabel.Text = reader["model"].ToString();
                                orders_carColorLabel.Text = reader["color"].ToString();
                                orders_carYearLabel.Text = reader["year"].ToString();
                                orders_carVINLabel.Text = reader["VIN"].ToString();
                                orders_statusTextBox.Text = reader["status"].ToString();
                                orders_carCostLabel.Text = reader["price"].ToString();

                                DataBank.orders_selectedCarBrand = reader["brand"].ToString();
                                DataBank.orders_selectedCarModel = reader["model"].ToString();
                                DataBank.orders_selectedCarGear = reader["gear"].ToString();
                                DataBank.orders_selectedCarEngine = reader["engine"].ToString();
                                DataBank.orders_selectedCarBody = reader["body"].ToString();
                                DataBank.orders_selectedCarDrive = reader["drive"].ToString();
                            }
                        }
                        reader.Close();
                    }

                }

                var fullstr = orders_statusTextBox.Text;
                string[] strs = fullstr.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in strs)
                {
                    selectedUserID = str;
                    if (int.TryParse(str, out int value))
                    {
                        DataBank.buyer_id = value;
                    }
                }

                using (SqlCommand cmd = new SqlCommand(getNames, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", dataGridView2[4, dataGridView1.CurrentRow.Index].Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                orders_sellerTextBox.Text = reader["user_name"].ToString();
                            }
                        }
                        reader.Close();
                    }

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", dataGridView2[5, dataGridView1.CurrentRow.Index].Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                orders_buyerTextBox.Text = reader["user_name"].ToString();
                            }
                        }
                        reader.Close();
                    }

                }
                con.Close();
            }

        }

        private void orders_statusesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            orders_statusTextBox.Text = orders_statusesComboBox.Text + $" ({DataBank.buyer_id})"; 
        }

        private void CarsData_deleteCombinationButton_Click(object sender, EventArgs e)
        {
            string query = "delete from brandModel where id = @id";
            var fullstr = CarsData_combosComboBox.Text;
            string[] strs = fullstr.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int selected_combo = 0; 
            foreach (string str in strs)
            {
                if (int.TryParse(str, out int value))
                {
                    selected_combo = value;
                }
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", selected_combo);
                    cmd.ExecuteNonQuery();
                    refreshCombosComboBox();
                }
                con.Close();
                MessageBox.Show("Успешно!");
            }
        }

        private void orders_ChangeStatusButton_Click(object sender, EventArgs e)
        {
            string query = "update car set status = @status where VIN = @VIN";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@status", orders_statusTextBox.Text);
                    cmd.Parameters.AddWithValue("@VIN", orders_carVINLabel.Text);
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }
            RefreshTables();
            MessageBox.Show("Успешно!");

        }

        private void orders_DeleteOrderButton_Click(object sender, EventArgs e)
        {
            string query = @"update car set status = 'В продаже' where VIN = @VIN;
                delete from orders where VIN = @VIN;";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VIN", orders_carVINLabel.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            RefreshTables();
            MessageBox.Show("Успешно!");
        }

        private void orders_CreateContract_Click(object sender, EventArgs e)
        {
            string fileName = "";
            void performReplaces() 
            {
                using (WordprocessingDocument originalDocument = WordprocessingDocument.Open(fileName, true))
                {
                    using (WordprocessingDocument newDocument = WordprocessingDocument.Create("blank.docx", WordprocessingDocumentType.Document))
                    {
                        newDocument.AddMainDocumentPart();
                        newDocument.MainDocumentPart.Document = (DocumentFormat.OpenXml.Wordprocessing.Document)originalDocument.MainDocumentPart.Document.Clone();
                        ReplaceText(newDocument.MainDocumentPart, "sellerName", orders_sellerTextBox.Text);
                        ReplaceText(newDocument.MainDocumentPart, "buyerName", orders_buyerTextBox.Text);
                        ReplaceText(newDocument.MainDocumentPart, "carBrand", orders_carNameLabel.Text);
                        ReplaceText(newDocument.MainDocumentPart, "carModel", orders_carModelLabel.Text);
                        ReplaceText(newDocument.MainDocumentPart, "carVIN", orders_carVINLabel.Text);
                        ReplaceText(newDocument.MainDocumentPart, "carYear", orders_carYearLabel.Text);
                        ReplaceText(newDocument.MainDocumentPart, "carEngine", DataBank.orders_selectedCarEngine);
                        ReplaceText(newDocument.MainDocumentPart, "carDrive", DataBank.orders_selectedCarDrive);
                        ReplaceText(newDocument.MainDocumentPart, "carBody", DataBank.orders_selectedCarBody);
                        ReplaceText(newDocument.MainDocumentPart, "carColor", orders_carColorLabel.Text);
                        ReplaceText(newDocument.MainDocumentPart, "carCost", orders_carCostLabel.Text);
                        newDocument.Save();
                    }
                }

            }
            if (Convert.ToInt32(dataGridView2[4, dataGridView1.CurrentRow.Index].Value) != 2)
            {
                fileName = "patternforpeople2.docx";
                performReplaces();
            }
            else
            {
                fileName = "patternforshop2.docx";
                performReplaces();
            }
            
            MessageBox.Show("Файл сохранен!");
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = $@"update car set status = 'Продано ({dataGridView2[5, dataGridView1.CurrentRow.Index].Value})' 
                    where VIN = @VIN";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VIN", orders_carVINLabel.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            RefreshTables();
            
        }

        static void ReplaceText(MainDocumentPart mainPart, string oldValue, string newValue)
        {
            foreach (Text text in mainPart.Document.Body.Descendants<Text>())
            {
                if (text.Text.Contains(oldValue))
                {
                    text.Text = text.Text.Replace(oldValue, newValue);
                }
            }
        }

        private void settings_UpdateProfileButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "update users set user_name = @user_name where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@user_name", settings_nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@id", DataBank.client_ID);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Успешно!");
            }
        }
    }
 }

