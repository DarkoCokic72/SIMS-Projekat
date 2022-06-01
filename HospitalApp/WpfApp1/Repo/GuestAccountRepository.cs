using System;
using System.Collections.Generic;
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

        public bool Add(GuestAccount guestAccount)
        {
            List<GuestAccount> guestAccountList = GetAll();
            guestAccountList.Add(guestAccount);
            guestAccountFileHandler.Save(guestAccountList);
            return true;
        }

        public bool Update(GuestAccount guestAccount)
        {
            List<GuestAccount> guestAccountList = GetAll();

           /* if (GuestAccountsWindow.guestAccountsWindowInstance.getSelectedGuestAccount().UniquePersonalNumber != guestAccount.UniquePersonalNumber)
            {
                for (int i = 0; i < guestAccountList.Count; i++)
                {

                    if (guestAccountList[i].UniquePersonalNumber.Equals(guestAccount.UniquePersonalNumber))
                    {
                        GuestAccountsEdit.editedGuestAccount = false;
                        return;
                    }
                }
            }*/

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