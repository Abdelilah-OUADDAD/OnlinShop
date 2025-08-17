using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopData
{
    public class clsCustomerData
    {
        static public int AddCustomer(string Name, string Email, string Address,int PaymentID)
        {
            int FinallyResult = 0;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"INSERT INTO Customer
                                   (Name
                                   ,Email
                                   ,Address
                                   ,PaymentID)
                             VALUES
                                   (@Name
                                   ,@Email
                                   ,@Address
                                   ,@PaymentID)
                              select SCOPE_IDENTITY()


                    ";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);
                    try
                    {
                        con.Open();

                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(),out int intResult))
                        {
                            FinallyResult = intResult;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return FinallyResult;

        }
    }
}
