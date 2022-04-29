using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace WpfApp1.Repo
{
    public class ManagerRepository
    {
        public List<Manager> GetAll()
        {
            return managerFileHandler.Read();
        }

        public FileHandler.ManagerFileHandler managerFileHandler;

        public ManagerRepository(ManagerFileHandler fileHandler)
        {
            managerFileHandler = fileHandler;
        }

    }
}
