using System;
using System.Collections.Generic;
using System.Text;
using FileHandler;
using Model;
using WpfApp1;
using WpfApp1.Model;

namespace Repo
{
    public class GuestAccountRepository
    {
        public List<GuestAccount> GetAll()
        {
            return guestAccountFileHandler.Read();
        }
        public List<GuestAccount> IsGuestAccount()
        {
            List<GuestAccount> guests = GetAll();
            List<GuestAccount> isGuestAccount = new List<GuestAccount>();
            foreach (GuestAccount guest in guests)
            {
                if (guest.IsGuestAccount)
                {
                    isGuestAccount.Add(guest);
                }
            }
            return isGuestAccount;
        }
        public bool UPNExists(string upn)
        {
            foreach (GuestAccount user in GetAll())
            {
                if (user.UniquePersonalNumber == upn) return true;
            }
            return false;
        }
        public bool EmailExists(string email)
        {
            foreach (GuestAccount user in GetAll())
            {
                if (user.Email == email) return true;
            }
            return false;
        }
        public GuestAccount GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            List<GuestAccount> guestAccountList = GetAll();
            foreach (GuestAccount account in guestAccountList)
            {
                if (account.UniquePersonalNumber == uniquePersonalNumber)
                {
                    return account;
                }

            }

            return null;
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public bool Add(GuestAccount guestAccount)
        {
            List<GuestAccount> guestAccountList = GetAll();
            guestAccount.IsGuestAccount = true;
            guestAccount.Password = CreatePassword(15);
            guestAccountList.Add(guestAccount);
            guestAccountFileHandler.Save(guestAccountList);
            return true;
        }

        public bool Update(GuestAccount guestAccount)
        {
            List<GuestAccount> guestAccountList = GetAll();

            for (int i = 0; i < guestAccountList.Count; i++)
            {
                if (guestAccountList[i].UniquePersonalNumber.Equals(guestAccount.UniquePersonalNumber))
                {
                    guestAccountList[i] = guestAccount;
                    guestAccountFileHandler.Save(guestAccountList);
                    return true;
                }
            }

            return false;
        }

        public void Remove(string id)
        {
            List<GuestAccount> guestAccountList = GetAll();

            for (int i = 0; i < guestAccountList.Count; i++)
            {
                if (guestAccountList[i].UniquePersonalNumber == id)
                {
                    guestAccountList.Remove(guestAccountList[i]);
                }
            }

            guestAccountFileHandler.Save(guestAccountList);
        }

        public GuestAccountFileHandler guestAccountFileHandler;

        public GuestAccountRepository(GuestAccountFileHandler fileHandler)
        {
            guestAccountFileHandler = fileHandler;
        }

    }
}