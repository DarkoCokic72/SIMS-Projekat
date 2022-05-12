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

        public GuestAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return guestAccountService.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public void Add(GuestAccount guestAccount)
        {
            guestAccountService.Add(guestAccount);
        }

        public void Update(GuestAccount guestAccount)
        {
            guestAccountService.Update(guestAccount);
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