using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Repo.UserAccountRepository userAccountRepository;

        public UserAccountService(UserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

    }
}
