using OnlineShopControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineShop
{
    public partial class frmOrder: Form
    {

        private int Quantity { get; set; }
        private int ProductID { get; set; }
        private decimal Price { get; set; }

        clsPayment payment;
        clsCustomer customer;
        clsOrder order;
        public frmOrder()
        {
            InitializeComponent();
        }

        public frmOrder(int quantity ,int productID, decimal price, string Name)
        {
            InitializeComponent();
            Quantity = quantity;
            ProductID = productID;
            Price = price;
            lblTitle.Text = $"Order Product {Name}";
        }

        private void AddCustomer()
        {
            customer = new clsCustomer();

            customer.Name = txtName.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            customer.PaymentID = payment.PaymentID;
            if (customer.Save())
            {
                payment.Withraw = Convert.ToDecimal(lblPrice.Text);

                AddOrder();


                if (MessageBox.Show($@"Price: {lblPrice.Text} - Quantity: {numUpDownQuantity.Value} Are you sure To Buying the Product?"
                    , "Buying", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                      && payment.Save() && order.Save() && clsProduct.UpdateQuantity(ProductID, Convert.ToInt32(numUpDownQuantity.Value)))
                {
                    
                    MessageBox.Show("Operation Buying got successfully !", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Operation Buying failed !", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
        private bool CheckPayment()
        {
            payment = clsPayment.GetPaymentCodeSecurity(Convert.ToInt32(txtCode.Text));
            return payment != null;
        }

        private void AddOrder()
        {
            order = new clsOrder();
            order.Date = DateTime.Now;
            order.Quantity = (int)numUpDownQuantity.Value;
            order.ProductID = this.ProductID;
            order.CustomID = customer.CustomerID;
            order.TotalPrice = Convert.ToDecimal(lblPrice.Text);
            order.Status = "Payment Confirm";


        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (CheckPayment())
                {
                    if (payment.Amount >= Convert.ToDecimal(lblPrice.Text))
                        AddCustomer();
                    else
                        MessageBox.Show("Your Amount is not enough to buying this product!", "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Code Security is False Try again !", "Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
                
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            numUpDownQuantity.Maximum = Quantity;
            lblPrice.Text = Price.ToString();
        }

        private void numUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblPrice.Text = (Price * numUpDownQuantity.Value).ToString();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtName,errorProvider1,e);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtEmail, errorProvider1, e);
            if (!clsGlobal.IsValidEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Something wrong in this email.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, ""); // Clear error
                e.Cancel = false;
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtAddress, errorProvider1, e);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            clsGlobal.Validating(txtCode, errorProvider1, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPress(sender, e);
        }
    }
}
