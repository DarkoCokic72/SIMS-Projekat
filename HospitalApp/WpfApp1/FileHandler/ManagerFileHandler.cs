using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.FileHandler
{
    public class ManagerFileHandler
    {

        public List<Manager> Read()
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<Manager>();
            }

            string managerSerialized = System.IO.File.ReadAllText(path);
            List<Manager> manager = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Manager>>(managerSerialized);
            return manager;
        }

        public void Save(List<Manager> manager)
        {
            string managerSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(manager);
            System.IO.File.WriteAllText(path, managerSerialized);
        }

        private string path = @"..\..\Data\Managers.txt";
    }
}
