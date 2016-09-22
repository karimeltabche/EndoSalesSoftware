using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WorkProjectV3
{
    public partial class frmAddDeleteSeller : Form
    {
        OleDbConnection conn = new OleDbConnection();

        public frmAddDeleteSeller()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=seller.accdb;
                Persist Security Info=False;";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = "select DISTINCT businessName from SellerInventory order by businessName asc";

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbBusiness.Items.Add(reader["businessName"].ToString());
            }

            conn.Close();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBusiness.Text == "")
                {
                    MessageBox.Show("Enter Business Name");
                }
                else if (txtItemName.Text == "")
                {
                    MessageBox.Show("Enter Item Name");
                }
                else if (txtPhoneNum.Text == "")
                {
                    MessageBox.Show("Enter Phone number");
                }
                else
                {
                    conn.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conn;
                    command.CommandText = "insert into SellerInventory (businessName,itemName,phoneNumber,price) values('" + cmbBusiness.Text + "', '" + txtItemName.Text + "', '" + txtPhoneNum.Text + "', '" + txtPrice.Text + "')";

                    command.ExecuteNonQuery();
                    MessageBox.Show("Item has been added successfully");
                    conn.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Enter Id to delete an item");
                }
                else
                {
                    conn.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conn;
                    command.CommandText = "delete from SellerInventory where id=" + txtId.Text + "";

                    command.ExecuteNonQuery();
                    MessageBox.Show("Id # " + txtId.Text + " has been deleted successfully");
                    conn.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void cmbBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                command.CommandText = "select * from SellerInventory where businessName='" + cmbBusiness.Text + "'";

                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                   txtPhoneNum.Text=  reader["phoneNumber"].ToString();
                }


                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}

