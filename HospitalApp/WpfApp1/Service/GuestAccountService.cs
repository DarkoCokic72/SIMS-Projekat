using System;
using System.Collections.Generic;
using Model;
using Repo;
using WpfApp1.Model;

namespace Service
{
    public class GuestAccountService
    {
        public List<GuestAccount> GetAll()
        {
            return guestAccountRepository.GetAll();
        }
        public List<GuestAccount> IsGuestAccount()
        {
            return guestAccountRepository.IsGuestAccount();
        }
        public bool UPNExists(string upn)
        {
            return guestAccountRepository.UPNExists(upn);
        }
        public bool EmailExists(string email)
        {
            return guestAccountRepository.EmailExists(email);
        }

        public GuestAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return guestAccountRepository.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public bool Add(GuestAccount guestAccount)
        {
            return guestAccountRepository.Add(guestAccount);
        }

        public bool Update(GuestAccount guestAccount)
        {
            return guestAccountRepository.Update(guestAccount);
        }

        public void Remove(string id)
        {
            guestAccountRepository.Remove(id);
        }

        public GuestAccountRepository guestAccountRepository;

        public GuestAccountService(GuestAccountRepository guestAccountRepository)
        {
            this.guestAccountRepository = guestAccountRepository;
        }

    }
}