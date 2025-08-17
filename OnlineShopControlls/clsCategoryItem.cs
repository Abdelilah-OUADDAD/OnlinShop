using OnlineShopData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShopControlls
{
    public class clsCategoryItem
    {
        public int CategoryItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public clsCategoryItem(int categoryItemID, string name, string description, int categoryID)
        {
            CategoryItemID = categoryItemID;
            Name = name;
            Description =description ;
            CategoryID =categoryID;
        }

        public clsCategoryItem()
        {

        }

        static public DataTable GetCategoryItemsWithCategoryID(int CategoryID)
        {
            return clsCategoryItemData.GetCategoryItemsWithCategoryID(CategoryID);
        }

        static public DataTable GetAllCategoryItems()
        {
            return clsCategoryItemData.GetAllCategoryItems();
        }

        static public clsCategoryItem GetCategoryItemsIDWithName(string Name)
        {

            string description = "";
            int categoryID = 0, categoryItemID = 0;
            if(clsCategoryItemData.GetCategoryItemsIDWithName(ref categoryItemID, Name, ref description, ref categoryID))
                return new clsCategoryItem(categoryItemID, Name, description, categoryID);

            return null;

        }

        static public clsCategoryItem GetCategoryItem(int categoryItemID)
        {
            string name = "",  description = "";
            int categoryID = 0;
            if (clsCategoryItemData.GetCategoryItem(categoryItemID, ref name, ref description, ref categoryID))
                return new clsCategoryItem(categoryItemID, name, description, categoryID);
            return null;
        }
    }
}
