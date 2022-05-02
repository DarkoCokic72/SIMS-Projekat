using FileHandler;
using Model;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

            SecretaryFileHandler secretaryFileHandler = new SecretaryFileHandler();
            SecretaryRepository secretaryRepository = new SecretaryRepository(secretaryFileHandler);

            PhysicianFileHandler physicianFileHandler = new PhysicianFileHandler();
            PhysicianRepository physicianRepository = new PhysicianRepository(physicianFileHandler);

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
            foreach (UserAccount u in physicianRepository.GetAll())
            {
                if (u.email == email && u.password == password)
                {
                    return u;
                }

            }
            foreach (UserAccount u in secretaryRepository.GetAll())
            {
                if (u.email == email && u.password == password)
                {
                    return u;
                }

            }
            MessageBox.Show("BAD LOGIN!\nWrong email or password!", "Error");
            return null;
        }

        public FileHandler.UserAccountFileHandler userAccountFileHandler;

        public UserAccountRepository(UserAccountFileHandler fileHandler)
        {
            userAccountFileHandler = fileHandler;
        }
    }
}