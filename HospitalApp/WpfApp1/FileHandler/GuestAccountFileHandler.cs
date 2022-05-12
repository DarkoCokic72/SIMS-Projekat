using System.Collections.Generic;
using Model;
using System;
using System.IO;
using System.Linq;
using WpfApp1.Model;

namespace FileHandler
{
    public class GuestAccountFileHandler
    {

        public List<GuestAccount> Read()
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<GuestAccount>();
            }

            string guestAccountsSerialized = System.IO.File.ReadAllText(path);
            List<GuestAccount> guestAccounts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GuestAccount>>(guestAccountsSerialized);
            return guestAccounts;
        }

        public void Save(List<GuestAccount> guestAccounts)
        {
            string guestAccountsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(guestAccounts);
            System.IO.File.WriteAllText(path, guestAccountsSerialized);
        }

        private string path = @"..\..\Data\GuestAccounts.txt";
    }
}