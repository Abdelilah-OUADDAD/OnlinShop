using OnlineShopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShopControlls
{
    public class clsPayment
    {
        public int PaymentID { get; set; }
        public int CodeSecurity { get; set; }
        public decimal Amount { get; set; }
        public decimal Withraw { get; set; }

        enum enMode { enAdd = 0, enUpdate = 1 }
        enMode Mode = enMode.enAdd;
        public clsPayment()
        {
            Mode = enMode.enAdd;
        }

        public clsPayment(int paymentID, int codesecurity,decimal amount)
        {
            PaymentID = paymentID;
            CodeSecurity = codesecurity;
            Amount = amount;
            Mode = enMode.enUpdate;
        }

        public static clsPayment GetPaymentCodeSecurity(int codesecurity)
        {
            int PaymentID = 0; decimal Amount = 0;

            if (clsPaymentData.GetPaymentCodeSecurity(codesecurity, ref PaymentID, ref Amount))
                return new clsPayment(PaymentID, codesecurity, Amount);

            return null;
        }

        private bool UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(PaymentID, Withraw);
        }

        public bool Save()
        {
            if (Mode == enMode.enAdd)
            {
               // code Add
            }
            else
            {
                if (UpdatePayment())
                    return true;
            }

            return false;
        }
    }
}
