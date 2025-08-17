using Microsoft.Win32;
using OnlineShopControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class frmLog: Form
    {

        string path = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourOnlineShop";
        //string SubKey = @"\YourOnlineShop";
        public frmLog()
        {
            InitializeComponent();
            if((Registry.GetValue(path,"UserName",null) as string != "") && (Registry.GetValue(path, "Password", null) as string != ""))
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }


            txtUserName.Text = Registry.GetValue(path, "UserName", null).ToString();
            txtPassword.Text = Registry.GetValue(path, "Password", null).ToString();
        }

        bool IsLogin()
        {
            clsGlobal.Login = clsLogin.GetLoginUser(txtUserName.Text, txtPassword.Text);
            return clsGlobal.Login != null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsLogin())
            {
                if (checkBox1.Checked)
                    LogDataInRegistry(txtUserName.Text,txtPassword.Text);
                else
                    LogDataInRegistry("","");

                clsGlobal.IsLogin = true;

                this.Close();
            }
            else
                MessageBox.Show("UserName or Password is Incorrect Try Again!", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void LogDataInRegistry(string Name,string Password)
        {
            try
            {
                Registry.SetValue(path, "UserName", Name, RegistryValueKind.String);
                Registry.SetValue(path, "Password", Password, RegistryValueKind.String);
            }
            catch(Exception ex)
            {
                string sourceName = "OnlineShop";


                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                    Console.WriteLine("Event source created.");
                }


                // Log an information event
                EventLog.WriteEntry(sourceName,ex.Message,EventLogEntryType.Error);
            }
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
           
        }
    }
}
