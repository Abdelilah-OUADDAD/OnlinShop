using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShopControlls;
using System.Resources;
using OnlineShop.Properties;
using OnlineShop.FolderCRUD;

namespace OnlineShop
{
    public partial class ctrlProducts: UserControl
    {
        public int CategoryID { get; set; }
        public ctrlProducts()
        {
            InitializeComponent();
        }


        private void ctrlProducts_Load(object sender, EventArgs e)
        {
            if (CategoryID == 1)
            {
                lblTitle.Text = "Cookware Items";
                this.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Desktop\Project_Windows-Forms\OnlineShop\OnlineShop\Ressource\Background_CookwareSets.jpg");
            }
            else if (CategoryID == 2)
            {
                lblTitle.Text = "Eating Utensils Items";
                this.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Desktop\Project_Windows-Forms\OnlineShop\OnlineShop\Ressource\Background_Eating_Utensils.jpg");
            }
            else if (CategoryID == 3)
            {
                lblTitle.Text = "Food Items";
                this.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Desktop\Project_Windows-Forms\OnlineShop\OnlineShop\Ressource\Background_Food.jpg");
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                foreach (DataRow item in clsCategoryItem.GetCategoryItemsWithCategoryID(CategoryID).Rows)
                {
                    comboBox1.Items.Add(item[0]);
                }
            }
        }
        public void Refresh()
        {
            DataTable data = clsProduct.GetProductCategoriesItemID(clsCategoryItem.GetCategoryItemsIDWithName(comboBox1.SelectedItem.ToString()).CategoryItemID);
            dataGridView1.DataSource = data;

            if (data.Rows.Count != 0)
            {
                dataGridView1.Columns[0].HeaderText = "ProductID";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[1].Width = 150;

                dataGridView1.Columns[2].HeaderText = "Quantity";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[3].Width = 90;

                dataGridView1.Columns[4].HeaderText = "Description";
                dataGridView1.Columns[4].Width = 300;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.IsLogin)
            {
                frmAddProduct frm = new frmAddProduct(comboBox1.Text);
                frm.ShowDialog();
                Refresh();
            }
            else
            {
                frmLog frm = new frmLog();
                frm.ShowDialog();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.IsLogin)
            {
                frmUpdateProduct frm = new frmUpdateProduct((int)dataGridView1.CurrentRow.Cells[0].Value, comboBox1.Text);
                frm.ShowDialog();
                Refresh();
            }
            else
            {
                frmLog frm = new frmLog();
                frm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.IsLogin)
            {
                int IDproduct = (int)dataGridView1.CurrentRow.Cells[0].Value;
                if (clsProduct.DeleteProduct(IDproduct))
                    MessageBox.Show($"ProductID {IDproduct} Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show($"Deleted Operation is Failed!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Refresh();
            }
            else
            {
                frmLog frm = new frmLog();
                frm.ShowDialog();
            }
        }
    }
}
