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

namespace OnlineShop
{
    public partial class frmProduct: Form
    {
        int _ProductID { get; set; }
        public frmProduct()
        {
            InitializeComponent();
        }

        public frmProduct(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
        }
        clsProduct data;
        private void frmProduct_Load(object sender, EventArgs e)
        {
            data = clsProduct.GetProductID(_ProductID);

            lblName.Text = data.Name;
            lblQuantity.Text = data.Quantity.ToString();
            lblPrice.Text = data.Price.ToString();
            txtDescription.Text = data.Description;
            pbImage.ImageLocation = data.Image;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrdered_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder(data.Quantity,data.ProductID,data.Price,data.Name);
            frm.ShowDialog();
        }
    }
}
