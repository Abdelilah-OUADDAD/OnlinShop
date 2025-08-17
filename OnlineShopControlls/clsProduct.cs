using OnlineShopData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopControlls
{
    public class clsProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryItemID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        enum enMode { enAdd = 0,enUpdate = 1}
        enMode Mode = enMode.enAdd;
        public clsProduct()
        {
            Mode = enMode.enAdd;
        }

        public clsProduct(int productID, string name, int quantity, decimal price, int categoryItemID, string description, string image)
        {
            ProductID = productID;
            Name = name;
            Quantity = quantity;
            Price = price;
            CategoryItemID = categoryItemID;
            Description = description;
            Image = image;
            Mode = enMode.enUpdate;
        }

        static public DataTable GetProductCategoriesItemID(int CategoryItemID)
        {
            return clsProductData.GetProductCategoriesItemID(CategoryItemID);
        }

        static public clsProduct GetProductID(int ProductID)
        {
            int categoryItemID = 0, quantity = 0;
            string name = "", description = "", image = "";
            decimal price = 0;
            if (clsProductData.GetProductID(ProductID, ref name, ref quantity, ref price, ref categoryItemID, ref description, ref image))
                return new clsProduct(ProductID, name, quantity, price, categoryItemID, description, image);

            return null;
        }

        static public bool UpdateQuantity(int ProductID, int Withdraw)
        {
           return clsProductData.UpdateQuantity(ProductID, Withdraw);
        }

        private int AddProduct()
        {
            return clsProductData.AddProduct(Name, Quantity, Price, CategoryItemID, Description, Image);
        }

        private bool UpdateProduct()
        {
            return clsProductData.UpdateProduct(ProductID,Name, Quantity, Price, CategoryItemID, Description, Image);
        }

        public bool Save()
        {
            if(Mode == enMode.enAdd)
            {
                ProductID = AddProduct();
                if (ProductID > 0)
                    return true;
            }
            else
            {
                if (UpdateProduct())
                    return true;
            }

            return false;
        }

        static public bool DeleteProduct(int ProductID)
        {
            return clsProductData.DeleteProduct(ProductID);
        }

    }

}
