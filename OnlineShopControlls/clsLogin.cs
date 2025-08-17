using OnlineShopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopControlls
{
    public class clsLogin
    {

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public clsLogin(int userID, string name, string password)
        {
            UserID = userID;
            Name = name;
            Password = password;
        }

        public clsLogin()
        {
            
        }

        public static clsLogin GetLoginUser(string Name, string Password)
        {
            int UserID = 0 ;
            if (clsLoginData.GetLoginUser(ref UserID, Name, Password))
                return new clsLogin(UserID, Name, Password);

            return null;
        }
    }
}
