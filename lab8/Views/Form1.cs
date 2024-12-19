using lab8.Models;
using lab8.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8.Views
{
    public partial class Form1 : Form, IOrderView
    {
        public event EventHandler AddOrder;
        public event EventHandler UpdateOrder;
        public event EventHandler DeleteOrder;
        public event EventHandler ViewOrders;

        public int OrderId { get; set; }
        public string OrderClient
        {
            get { return txtClient.Text; }
            set { txtClient.Text = value; }
        }

        public string OrderProblem
        {
            get { return txtProblem.Text; }
            set { txtProblem.Text = value; }
        }

        public string OrderMaster
        {
            get { return txtMaster.Text; }
            set { txtMaster.Text = value; }
        }

        public void DisplayOrders(DataTable orders)
        {
            dataGridView1.DataSource = orders;
        }

        public Form1()
        {
            InitializeComponent();

            var model = new OrderModel();
            var presenter = new OrderPresenter(this, model);

            //btnAdd.Click += (s, e) => AddOrder?.Invoke(s, e);
            //btnView.Click += (s, e) => ViewOrders?.Invoke(s, e);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ViewOrders?.Invoke(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClient.Text == "" || txtMaster.Text == "" || txtProblem.Text == "")
                {
                    MessageBox.Show("Что-то пошло не так");
                }
                else
                {
                    AddOrder?.Invoke(sender, e);
                }
                
            }
            catch (Exception) 
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    OrderId = orderId;
                    DeleteOrder?.Invoke(sender, e);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите студента для удаления.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    OrderId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    UpdateOrder?.Invoke(sender, e);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите студента для обновления.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
