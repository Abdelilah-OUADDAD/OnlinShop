using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.FolderCRUD
{
    public partial class frmUpdateProduct: Form
    {
        public frmUpdateProduct()
        {
            InitializeComponent();

        }

        public frmUpdateProduct(int ProductID, string CategoryName)
        {
            InitializeComponent();

            ctrlCRUD1.Title = "Update Product";
            ctrlCRUD1.CategoryName = CategoryName;
            ctrlCRUD1.FileDataProduct(ProductID);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ctrlCRUD1.UpdateDataProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
