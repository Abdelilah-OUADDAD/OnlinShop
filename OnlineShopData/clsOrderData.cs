using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopData
{
    public class clsOrderData
    {
        static public int AddOrder(DateTime Date, int Quantity, int ProductID,int CustomerID, decimal TotalPrice,string Status)
        {
            int FinallyResult = 0;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"INSERT INTO Orders
                                   (Date
                                   ,Quantity
                                   ,ProductID
                                   ,CustomerID
                                   ,TotalPrice
                                   ,Status)
                                 VALUES
                                   (@Date
                                   ,@Quantity
                                   ,@ProductID
                                   ,@CustomerID
                                   ,@TotalPrice
                                   ,@Status)
                                  select SCOPE_IDENTITY()


                    ";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                    command.Parameters.AddWithValue("@Status", Status);
                    try
                    {
                        con.Open();

                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int intResult))
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
