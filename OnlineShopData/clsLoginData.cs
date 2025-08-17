using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopData
{
    public class clsLoginData
    {
        static public bool GetLoginUser(ref int UserID,string Name, string Password)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"select UserID, Name , Password from Login where Name = @Name and Password = @Password";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                Password = (string)reader["Password"];
                                UserID = (int)reader["UserID"];

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
    }
}
