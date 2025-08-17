using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopData
{
    public class clsDataAccessSetting
    {
        static public string ConnectionString = @"server=.; database = E_Commerce; User ID= sa ; Password = sa123456 ";

        public static void SetEventLog(string MessageText, EventLogEntryType type)
        {
            // Specify the source name for the event log
            string sourceName = "OnlineShop";


            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
                Console.WriteLine("Event source created.");
            }


            // Log an information event
            EventLog.WriteEntry(sourceName, MessageText, type);

        }
    }
}
