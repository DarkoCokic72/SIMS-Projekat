/***********************************************************************
 * Module:  GuestAccount.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GuestAccount
 ***********************************************************************/

using Model;
using System;
using WpfApp1.Model;

namespace WpfApp1.Model
{
    public class GuestAccount : UserAccount
    {
        public GuestAccount(String email, String password, String name, String surname, String uniqueuniquePersonalNumber)
        {
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.UniquePersonalNumber = uniqueuniquePersonalNumber;
        }

    }
}