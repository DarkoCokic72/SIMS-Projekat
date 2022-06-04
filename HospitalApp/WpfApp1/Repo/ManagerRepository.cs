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

        public void EditManagerProfile(Manager newManager)
        {
            List<Manager> managers = GetAll();
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].UniquePersonalNumber == newManager.UniquePersonalNumber)
                {
                    managers[i].Name = newManager.Name;
                    managers[i].Surname = newManager.Surname;
                    managers[i].PhoneNumber = newManager.PhoneNumber;
                    managers[i].Email = newManager.Email;
                }
            }

            managerFileHandler.Save(managers);
        }

        public void ChangeManagerPassword(Manager newManager)
        {
            List<Manager> managers = GetAll();
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].UniquePersonalNumber == newManager.UniquePersonalNumber)
                {
                    managers[i].Password = newManager.Password;
                }
            }

            managerFileHandler.Save(managers);
        }

        public UserAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            foreach (Manager manager in GetAll())
            {
                if (manager.UniquePersonalNumber == uniquePersonalNumber)
                {
                    return manager;
                }
            }

            return null;
        }

        public FileHandler.ManagerFileHandler managerFileHandler = new ManagerFileHandler();

        public ManagerRepository() { }
        public ManagerRepository(ManagerFileHandler fileHandler)
        {
            managerFileHandler = fileHandler;
        }

    }
}
