using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopData
{
    public class clsPaymentData
    {
        static public bool GetPaymentCodeSecurity(int CodeSecurity, ref int PaymentID,ref decimal Amount)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"select PaymentID,CodeSecurity,Amount from Payment where CodeSecurity = @CodeSecurity";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CodeSecurity", CodeSecurity);
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if (reader.Read())
                            {
                                PaymentID = (int)reader["PaymentID"];
                                Amount = (decimal)reader["Amount"];
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

        static public bool UpdatePayment(int PaymentID,decimal Withdraw)
        {
            bool isAffected = false;
            using (SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"UPDATE Payment
                                   SET Amount = Amount - @Withdraw
                                 WHERE PaymentID = @PaymentID";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);
                    command.Parameters.AddWithValue("@Withdraw", Withdraw);
                    try
                    {
                        con.Open();

                        int Effect = command.ExecuteNonQuery();
                        if (Effect > 0)
                        {
                            isAffected = true;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        // Message in eventLog
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return isAffected;

        }
    }
}
