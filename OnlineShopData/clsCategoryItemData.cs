using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OnlineShopData
{
    public class clsCategoryItemData
    {
        static public DataTable GetCategoryItemsWithCategoryID(int CategoryID)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = "select Name , Description  from CategoryItems where CategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    try
                    {
                        con.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return dataTable;

        }

        static public DataTable GetAllCategoryItems()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = "select Name from CategoryItems";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    
                    try
                    {
                        con.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return dataTable;

        }

        static public bool GetCategoryItemsIDWithName(ref int CategoryItemID, string Name, ref string Description, ref int CategoryID)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = "select CategoryItemID , Description , CategoryID  from CategoryItems where Name = @Name";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CategoryItemID", CategoryItemID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    try
                    {
                        con.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            CategoryItemID = (int)reader["CategoryItemID"];
                            Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
                            CategoryID = (int)reader["CategoryID"];
                            isFound = true;
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

        static public bool GetCategoryItem(int CategoryItemID, ref string Name, ref string Description, ref int CategoryID)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = "select Name , Description , CategoryID  from CategoryItems where CategoryItemID = @CategoryItemID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CategoryItemID", CategoryItemID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    try
                    {
                        con.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            Name = (string)reader["Name"];
                            Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"];
                            CategoryID = (int)reader["CategoryID"];
                            isFound = true;
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
    }
}
