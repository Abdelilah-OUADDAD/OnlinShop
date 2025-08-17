using OnlineShopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopControlls
{
    public class clsCustomer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PaymentID { get; set; }

        enum enMode { enAdd = 0,enUpdate = 1 }
        enMode Mode = enMode.enAdd;
        public clsCustomer()
        {
            Mode = enMode.enAdd;
        }

        public clsCustomer(int customerID, string name, string email, string address, int paymentID)
        {
            CustomerID = customerID;
            Name = name;
            Email = email;
            Address = address;
            PaymentID = paymentID;
            Mode = enMode.enUpdate;
        }

        private int AddCustomer()
        {
            return clsCustomerData.AddCustomer(Name,Email,Address,PaymentID);
        }

        public bool Save()
        {
            if(Mode == enMode.enAdd)
            {
                CustomerID = AddCustomer();
                if (CustomerID > 0)
                    return true;
            }
            else
            {
                // code update
            }

            return false;
        }

    }
}
