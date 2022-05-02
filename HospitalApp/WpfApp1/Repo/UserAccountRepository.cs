using FileHandler;
using Model;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.FileHandler;

namespace WpfApp1.Repo
{
    public class UserAccountRepository
    {
        public List<UserAccount> GetAll()
        {
            return userAccountFileHandler.Read();
        }

        public UserAccount GetByEmailPassword(string email, string password)
        {
            List<UserAccount> userAccountList = GetAll();

            PatientFileHandler patientFileHandler = new PatientFileHandler();
            PatientRepository patientRepository = new PatientRepository(patientFileHandler);

            ManagerFileHandler managerFileHandler = new ManagerFileHandler();
            ManagerRepository managerRepository = new ManagerRepository(managerFileHandler);

            foreach (UserAccount u in patientRepository.GetAll())
            {
                if (u.email == email && u.password == password)
                {
                    return u;
                }

            }
            foreach (UserAccount u in managerRepository.GetAll())
            {
                if (u.email == email && u.password == password)
                {
                    return u;
                }

            }

            return null;
        }

        public FileHandler.UserAccountFileHandler userAccountFileHandler;

        public UserAccountRepository(UserAccountFileHandler fileHandler)
        {
            userAccountFileHandler = fileHandler;
        }
    }
}