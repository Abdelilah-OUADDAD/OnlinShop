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
    public partial class FrmHome: Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void pbCookware_Click(object sender, EventArgs e)
        {
            frmShowListProducts frm = new frmShowListProducts(1);
            frm.ShowDialog();
        }

        private void pbEatingUtensils_Click(object sender, EventArgs e)
        {
            frmShowListProducts frm = new frmShowListProducts(2);
            frm.ShowDialog();
        }

        private void pbFish_Click(object sender, EventArgs e)
        {
            frmShowListProducts frm = new frmShowListProducts(3);
            frm.ShowDialog();
        }
    }
}
