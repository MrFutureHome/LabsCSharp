using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLCarsApp
{
    public partial class LoginForm : Form
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings
            ["SQLCarsApp.Properties.Settings.carsSQLConnectionString"].ConnectionString;
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text.ToString() != "" && passwordTextBox.Text.ToString() != "")
            {
                using (SqlConnection con = new SqlConnection(ConnectionString)) 
                { 
                    con.Open();
                    string query = "select * from users where login = @login and password = @password";
                    string getInfoQuery = "select id, user_name, login from users where login = @login";
                    string checkForRoles = @"select user_id, role_id from userRole where user_id = @user_id";
                    string EncodedPassword = GetHash(passwordTextBox.Text);

                    using (SqlCommand cmd = new SqlCommand(getInfoQuery, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@login", loginTextBox.Text.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    DataBank.client_login = reader["login"].ToString();
                                    DataBank.client_name = reader["user_name"].ToString();
                                    DataBank.client_ID = Convert.ToInt32(reader["id"]);
                                }
                            }

                            else
                            {
                                MessageBox.Show("Пользователя с таким сочетанием логина и пароля нет в системе!");
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(checkForRoles, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@user_id", DataBank.client_ID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (Convert.ToInt32(reader["role_id"]) == 1)
                                    {
                                        DataBank.check_for_director = true;
                                    }
                                    if (Convert.ToInt32(reader["role_id"]) == 2)
                                    {
                                        DataBank.check_for_sysadmin = true;
                                    }
                                    if (Convert.ToInt32(reader["role_id"]) == 3)
                                    {
                                        DataBank.check_for_consult = true;
                                    }
                                    if (Convert.ToInt32(reader["role_id"]) == 4)
                                    {
                                        DataBank.check_for_manager = true;
                                    }
                                    if (Convert.ToInt32(reader["role_id"]) == 5)
                                    {
                                        DataBank.check_for_client = true;
                                    }
                                }
                            }
                        } 
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@login", loginTextBox.Text.ToString());
                        cmd.Parameters.AddWithValue("@password", EncodedPassword.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    Hide();
                                    MainForm mf = new MainForm();
                                    mf.Text = "Пользователь: " + reader["login"].ToString() + 
                                        "  ||  " + "ID: " + DataBank.client_ID.ToString();
                                    mf.Show();
                                }
                            }
                            else
                            {
                                return;
                            }
                        }

                    }

                    con.Close();
                }


            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            RegForm rf = new RegForm();
            rf.Show();
        }
    }
}
