using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Repo;

namespace WpfApp1.Service
{
    public class UserAccountService
    {
        public List<UserAccount> GetAll()
        {
            return userAccountRepository.GetAll();
        }

        public UserAccount GetByEmailPassword(string email, string password)
        {
            return userAccountRepository.GetByEmailPassword(email, password);
        }

        public void EditManagerProfile(Manager manager)
        {
            managerRepository.EditManagerProfile(manager);
        }

        public void ChangeManagerPassword(Manager manager)
        {
            managerRepository.ChangeManagerPassword(manager);
        }

        public UserAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return managerRepository.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public bool EmailAlreadyExists(string email)
        {
            return userAccountRepository.EmailAlreadyExists(email);
        }

        public UserAccountRepository userAccountRepository = new UserAccountRepository();
        public ManagerRepository managerRepository = new ManagerRepository();
        
        public UserAccountService() { }

        public UserAccountService(UserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

    }
}
