using FileHandler;
using Model;
using Repo;
using System.Collections.Generic;
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
            PhysicianRepository physicianRepository = new PhysicianRepository();

            foreach (UserAccount user in patientRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }

            }
            foreach (UserAccount user in managerRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }

            }
            foreach (UserAccount user in physicianRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }

            }
            foreach (UserAccount user in secretaryRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
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