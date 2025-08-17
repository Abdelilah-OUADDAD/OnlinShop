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
using OnlineShop.FolderCRUD;

namespace OnlineShop
{
    public partial class frmShowListProducts: Form
    {
        public frmShowListProducts()
        {
            InitializeComponent();
        }

        public frmShowListProducts(int categoryID)
        {
            InitializeComponent();
            ctrlProducts1.CategoryID = categoryID;
        }
        private void frmCookware_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
