using System;
using System.Collections.Generic;
using Model;
using Service;
using WpfApp1.Model;

namespace Controller
{
    public class GuestAccountController
    {
        public List<GuestAccount> GetAll()
        {
            return guestAccountService.GetAll();
        }
        public bool EmailExists(string email)
        {
            return guestAccountService.EmailExists(email);
        }
        public bool UPNExists(string upn)
        {
            return guestAccountService.UPNExists(upn);
        }
        public GuestAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return guestAccountService.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public bool Add(GuestAccount guestAccount)
        {
            return guestAccountService.Add(guestAccount);
        }

        public bool Update(GuestAccount guestAccount)
        {
            return guestAccountService.Update(guestAccount);
        }

        public void Remove(string id)
        {
            guestAccountService.Remove(id);
        }

        public Service.GuestAccountService guestAccountService;

        public GuestAccountController(GuestAccountService guestAccountService)
        {
            this.guestAccountService = guestAccountService;
        }

    }
}