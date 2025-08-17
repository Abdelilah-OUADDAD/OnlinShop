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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OnlineShop.Properties;

namespace OnlineShop.FolderCRUD
{
    public partial class ctrlCRUD: UserControl
    {
        public clsProduct product;
        public string Title { get; set; }

        public string CategoryName { get; set; }
        public ctrlCRUD()
        {
            InitializeComponent();
        }

        private void ctrlCRUD_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Title;
            DataTable CategoryItem = clsCategoryItem.GetAllCategoryItems();
            
            if (CategoryItem != null )
            {
                foreach (DataRow item in CategoryItem.Rows)
                {
                    cmbCategory.Items.Add(item[0].ToString().Trim());
                }
            }
            cmbCategory.SelectedItem = CategoryName;
        }

        public void AddDataProduct()
        {
            
            if (ValidateChildren() && cmbCategory.SelectedItem != null)
            {
                clsProduct product = new clsProduct();
                product.Name = txtName.Text;
                product.Quantity = Convert.ToInt32(txtQuantity.Text);
                product.Price = Convert.ToDecimal(txtPrice.Text);
                product.CategoryItemID = clsCategoryItem.GetCategoryItemsIDWithName(cmbCategory.SelectedItem.ToString()).CategoryItemID;
                product.Description = txtDescription.Text;
                product.Image = pbImage.ImageLocation;

                if (product.Save())
                    MessageBox.Show($"ProductID {product.ProductID} Add Successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show($"Operation Add is Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
                errorProvider1.SetError(cmbCategory, "This field is required");
        }

        public void FileDataProduct(int ProductID)
        {
            product = clsProduct.GetProductID(ProductID);
            txtName.Text = product.Name;
            txtQuantity.Text = product.Quantity.ToString();
            txtPrice.Text = product.Price.ToString();
            txtDescription.Text = product.Description;
            pbImage.ImageLocation = product.Image;

        }
        public void UpdateDataProduct()
        {

            if (ValidateChildren() && cmbCategory.SelectedItem != null)
            {
                clsProduct product2 = new clsProduct(product.ProductID, txtName.Text, Convert.ToInt32(txtQuantity.Text), Convert.ToDecimal(txtPrice.Text),
                 clsCategoryItem.GetCategoryItemsIDWithName(cmbCategory.SelectedItem.ToString()).CategoryItemID, txtDescription.Text, pbImage.ImageLocation);


                if (product2.Save())
                    MessageBox.Show($"Product {product.ProductID} Update Successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show($"Operation Update is Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                errorProvider1.SetError(cmbCategory, "This field is required");

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtName, errorProvider1, e);
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtQuantity, errorProvider1, e);
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtPrice, errorProvider1, e);
        }

        private void linkLblImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "Select an Image File";
            openFileDialog1.FileName = "Resource";
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    pbImage.ImageLocation = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Dispose of the OpenFileDialog
            openFileDialog1.Dispose();
        }

        private void linkLblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPress(sender, e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPress(sender, e);
        }
    }
}
