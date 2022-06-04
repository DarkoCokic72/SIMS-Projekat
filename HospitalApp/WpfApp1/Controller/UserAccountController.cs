using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
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

        public void EditManagerProfile(Manager manager)
        {
            userAccountService.EditManagerProfile(manager);
        }

        public void ChangeManagerPassword(Manager manager)
        {
            userAccountService.ChangeManagerPassword(manager);
        }

        public UserAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return userAccountService.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public Service.UserAccountService userAccountService = new UserAccountService();

        public UserAccountController() { }
        public UserAccountController(UserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

    }
}
