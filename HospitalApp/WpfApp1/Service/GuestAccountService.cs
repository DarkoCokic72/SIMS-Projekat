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

        public GuestAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return guestAccountRepository.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public void Add(GuestAccount guestAccount)
        {
            guestAccountRepository.Add(guestAccount);
        }

        public void Update(GuestAccount guestAccount)
        {
            guestAccountRepository.Update(guestAccount);
        }

        public void Remove(string id)
        {
            guestAccountRepository.Remove(id);
        }

        public Repo.GuestAccountRepository guestAccountRepository;

        public GuestAccountService(GuestAccountRepository guestAccountRepository)
        {
            this.guestAccountRepository = guestAccountRepository;
        }

    }
}