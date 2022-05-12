using System;
using System.Collections.Generic;
using FileHandler;
using Model;
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
            foreach (GuestAccount r in guestAccountList)
            {
                if (r.uniquePersonalNumber == uniquePersonalNumber)
                {
                    return r;
                }

            }

            return null;
        }

        public void Add(GuestAccount guestAccount)
        {
            List<GuestAccount> guestAccountList = GetAll();
            guestAccountList.Add(guestAccount);
            guestAccountFileHandler.Save(guestAccountList);
            WpfApp1.CreateGuestAccount.addedGuestAccount = true;

        }

        public void Update(GuestAccount guestAccount)
        {
            List<GuestAccount> guestAccountList = GetAll();

            if (WpfApp1.GuestAccountsWindow.guestAccountsWindowInstance.getSelectedGuestAccount().uniquePersonalNumber != guestAccount.uniquePersonalNumber)
            {
                for (int i = 0; i < guestAccountList.Count; i++)
                {

                    if (guestAccountList[i].uniquePersonalNumber.Equals(guestAccount.uniquePersonalNumber))
                    {
                        WpfApp1.GuestAccountsEdit.editedGuestAccount = false;
                        return;
                    }
                }
            }

            for (int i = 0; i < guestAccountList.Count; i++)
            {

                if (guestAccountList[i].uniquePersonalNumber.Equals(WpfApp1.GuestAccountsWindow.guestAccountsWindowInstance.getSelectedGuestAccount().uniquePersonalNumber))
                {

                    guestAccountList[i] = guestAccount;
                    guestAccountFileHandler.Save(guestAccountList);
                    WpfApp1.GuestAccountsEdit.editedGuestAccount = true;
                    return;

                }
            }
        }

        public void Remove(string id)
        {
            List<GuestAccount> guestAccountList = GetAll();

            for (int i = 0; i < guestAccountList.Count; i++)
            {
                if (guestAccountList[i].uniquePersonalNumber == id)
                {
                    guestAccountList.Remove(guestAccountList[i]);
                }
            }

            guestAccountFileHandler.Save(guestAccountList);
        }

        public FileHandler.GuestAccountFileHandler guestAccountFileHandler;

        public GuestAccountRepository(GuestAccountFileHandler fileHandler)
        {
            guestAccountFileHandler = fileHandler;
        }

    }
}