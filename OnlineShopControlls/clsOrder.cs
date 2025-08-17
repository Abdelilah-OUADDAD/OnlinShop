using OnlineShopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopControlls
{
    public class clsOrder
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public int CustomID { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        enum enMode { enAdd = 0, enUpdate = 1 }

        enMode Mode = enMode.enAdd;
        public clsOrder()
        {
            Mode = enMode.enAdd;
        }

        public clsOrder(int orderID,DateTime date, int quantity, int productID, int customID, decimal totalPrice, string status)
        {
            OrderID = orderID;
            Date = date;
            Quantity = quantity;
            ProductID = productID;
            CustomID = customID;
            TotalPrice = totalPrice;
            Status = status;

            Mode = enMode.enUpdate;
        }

        private int AddOrder()
        {
            return clsOrderData.AddOrder(Date,Quantity,ProductID,CustomID,TotalPrice,Status);
        }


        public bool Save()
        {
            if(Mode == enMode.enAdd)
            {
                OrderID = AddOrder();
                if (OrderID > 0)
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
