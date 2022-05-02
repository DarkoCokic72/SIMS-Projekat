using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.FileHandler
{
    public class UserAccountFileHandler
    {
        public List<UserAccount> Read()
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<UserAccount>();
            }

            string userAccountSerialized = System.IO.File.ReadAllText(path);
            List<UserAccount> userAccount = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserAccount>>(userAccountSerialized);
            return userAccount;
        }
        private string path = @"..\..\Data\UserAccount.txt";
    }
}
