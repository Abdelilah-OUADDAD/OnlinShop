using OnlineShopControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineShop.FolderCRUD
{
    public partial class frmAddProduct: Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        public frmAddProduct(string CategoryName)
        {
            InitializeComponent();
            ctrlCRUD1.Title = "Add Product";
            ctrlCRUD1.CategoryName = CategoryName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ctrlCRUD1.AddDataProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
