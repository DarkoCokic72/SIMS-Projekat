using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Service;

namespace WpfApp1.Controller

{
    public class UserAccountController
    {
        public List<UserAccount> GetAll()
        {
            return userAccountService.GetAll();
        }

        public UserAccount GetByEmailPassword(string email, string password)
        {
            return userAccountService.GetByEmailPassword(email, password);
        }

        public Service.UserAccountService userAccountService;

        public UserAccountController(UserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

    }
}
