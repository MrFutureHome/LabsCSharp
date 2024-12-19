using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace lab8.Models
{
    public class OrderModel
    {
        private string connectionString = "Data Source=DESKTOP-QRPM557;Initial Catalog=OrdersDB;Integrated Security=True;";
        
        public void CreateOrder(string orderClient, string orderProblem, string orderMaster)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Orders (Client, Problem, Master) VALUES (@Client, @Problem, @Master)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Client", orderClient);
                cmd.Parameters.AddWithValue("@Problem", orderProblem);
                cmd.Parameters.AddWithValue("@Master", orderMaster);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateOrder(int orderID, string orderClient, string orderProblem, string orderMaster)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE orders SET Client = @Client, Problem = @Problem, Master = @Master WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", orderID);
                cmd.Parameters.AddWithValue("@Client", orderClient);
                cmd.Parameters.AddWithValue("@Problem", orderProblem);
                cmd.Parameters.AddWithValue("@Master", orderMaster);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(int orderID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Orders WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", orderID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable RefreshOrders()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
