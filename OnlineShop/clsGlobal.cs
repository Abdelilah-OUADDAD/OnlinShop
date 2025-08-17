using OnlineShopControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop
{
    public class clsGlobal
    {
        static public clsLogin Login;
        static public bool IsLogin = false;
        public static void Validating(TextBox textBox,ErrorProvider errorProvider,CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider.SetError(textBox, "This field is required.");
                e.Cancel = true; // Prevent focus change if validation fails
            }
            else
            {
                errorProvider.SetError(textBox, ""); // Clear error
                e.Cancel = false;
            }
        }
        public static void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@gmail.com";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
