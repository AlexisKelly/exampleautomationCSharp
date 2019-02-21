using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHermesProject.UtilityHelper
{
    public class UserManager
    {
        public static string GetUserPasswordBy(string userEmail)
        {
            Dictionary<string, string> usernameAndPassword = new Dictionary<string, string>
            {
                {"Osifo12@yahoo.com",""},
                {"InvalidUser@yahoo.com", "Invalid Password" }
            };
            return usernameAndPassword[userEmail];
        }
    }
}
