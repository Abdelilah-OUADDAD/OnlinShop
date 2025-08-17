using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopData
{
    public class clsProductData
    {
        static public DataTable GetProductCategoriesItemID( int categoryItemID)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = "select ProductID, Name , Quantity, Price, Description  from Products where CategoryItemID = @CategoryItemID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CategoryItemID", categoryItemID);
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                data.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return data;

        }

        static public bool GetProductID( int productID, ref string name, ref int quantity, ref decimal price, ref int categoryItemID,
            ref string description, ref string image)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = "select  Name , Quantity, Price, Description, CategoryItemID,Image  from Products where ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ProductID", productID);
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                name = (string)reader["Name"];
                                quantity = (int)reader["Quantity"];
                                price = (decimal)reader["Price"];
                                categoryItemID = (int)reader["CategoryItemID"];
                                description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
                                
                                
                                image =  reader["Image"] == DBNull.Value ? null: (string)reader["Image"];
                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return isFound;

        }

        static public int AddProduct(string Name, int Quantity, decimal Price, int CategoryItemID, string Description, string Image)
        {
            int ProductID = 0;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"INSERT INTO Products
                                   (Name
                                   ,Quantity
                                   ,Price
                                   ,CategoryItemID
                                   ,Description
                                   ,Image)
                             VALUES
                                   (@Name
                                   ,@Quantity
                                   ,@Price
                                   ,@CategoryItemID
                                   ,@Description
                                   ,@Image)
                               select SCOPE_IDENTITY()     
                                    ";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@CategoryItemID", CategoryItemID);

                    if (Description != null)
                        command.Parameters.AddWithValue("@Description", Description);
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                    if (Image != null)
                        command.Parameters.AddWithValue("@Image", Image);
                    else
                        command.Parameters.AddWithValue("@Image", DBNull.Value);

                    try
                    {
                            con.Open();

                            object result = command.ExecuteScalar();
                            if (result != null && int.TryParse(result.ToString(), out int intResult))
                            {
                                ProductID = intResult;
                            }

                        }
                        catch (Exception ex)
                        {
                            // Message in eventLog
                            clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                        }

                }

            }

            return ProductID;
        }

        static public bool UpdateProduct(int ProductID, string Name, int Quantity, decimal Price, int CategoryItemID, string Description, string Image)
        {
            bool isUpdated = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"UPDATE Products
                                   SET Name = @Name
                                      ,Quantity = @Quantity
                                      ,Price = @Price
                                      ,CategoryItemID = @CategoryItemID
                                      ,Description = @Description
                                      ,Image = @Image
                                 WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@CategoryItemID", CategoryItemID);
                    if (Description != null)
                        command.Parameters.AddWithValue("@Description", Description);
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);

                    if (Image != null)
                        command.Parameters.AddWithValue("@Image", Image);
                    else
                        command.Parameters.AddWithValue("@Image", DBNull.Value);
                    try
                    {
                        con.Open();

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isUpdated = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return isUpdated;
        }

        static public bool DeleteProduct(int ProductID)
        {
            bool isDeleted = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"DELETE FROM Products WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    try
                    {
                        con.Open();

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isDeleted = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return isDeleted;
        }


        static public bool UpdateQuantity(int ProductID,int Withdraw)
        {
            bool isUpdated = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"UPDATE Products
                                   SET Quantity = Quantity - @Withdraw
                                 WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Withdraw", Withdraw);
                    try
                    {
                        con.Open();

                        int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                isUpdated = true;
                            }
                        
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return isUpdated;
        }
    }
}
