using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WorkProjectV2
{
    public partial class frmInventory : Form
    {

        public frmInventory()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddSellerItem f2 = new frmAddSellerItem();
            f2.ShowDialog();
        }

        private void btnSellerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lstSeller.Items.Clear();
                string sellerSearch = txtSellerSearch.Text;
                StreamReader inputFile;
                inputFile = File.OpenText(@"seller.txt");
                string bName, itemName, phone, space, line;
                string qty;
                int count = 0;
                string itemNum ;
                while (!inputFile.EndOfStream)
                {
                    //itemNum = inputFile.ReadLine();
                    bName = inputFile.ReadLine();
                    itemName = inputFile.ReadLine();
                    phone = inputFile.ReadLine();
                    qty = inputFile.ReadLine();
                    line = inputFile.ReadLine();
                    space = inputFile.ReadLine();

                    if (sellerSearch.ToLower() == itemName.ToLower() || itemName.ToLower().StartsWith(sellerSearch.ToLower()))
                    {
                       // lstSeller.Items.Add("Item #: " + itemNum );
                        lstSeller.Items.Add("Business Name: " + bName);
                        lstSeller.Items.Add("Item Name: " + itemName);
                        lstSeller.Items.Add("Phone: " + phone);
                        lstSeller.Items.Add("Quantity " + qty);
                        lstSeller.Items.Add(line);
                        lstSeller.Items.Add(space);
                        count += 1;
                    }
                   

            }
                if(count < 1)
                {
                    MessageBox.Show("Item not found");
                }
                inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDeleteSellerItem f4 = new frmDeleteSellerItem();
            f4.ShowDialog();

        }

        private void btnBuyerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lstBuyer.Items.Clear();
                string buyerSearch = txtBuyerSearch.Text;
                StreamReader inputFile;
                inputFile = File.OpenText(@"buyer.txt");
                string bName, itemName, phone, space, line;
                string qty;
                int itemNumber=0;
                int count = 0;
                while (!inputFile.EndOfStream)
                {

                    bName = inputFile.ReadLine();
                    itemName = inputFile.ReadLine();
                    phone = inputFile.ReadLine();
                    qty = inputFile.ReadLine();
                    line = inputFile.ReadLine();
                    space = inputFile.ReadLine();

                    if (buyerSearch == itemName || itemName.StartsWith(buyerSearch))
                    {
                        lstBuyer.Items.Add("Business Name: " + bName);
                        lstBuyer.Items.Add("Item Name: " + itemName);
                        lstBuyer.Items.Add("Phone: " + phone);
                        lstBuyer.Items.Add("Quantity " + qty);
                        lstBuyer.Items.Add(line);
                        lstBuyer.Items.Add(space);
                        count += 1;
                    }


                }
                if (count < 1)
                {
                    MessageBox.Show("Item not found");
                }
                inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddBuyerItem f3 = new frmAddBuyerItem();
            f3.ShowDialog();
        }

        
    }
}
