/***********************************************************************
 * Module:  Manager.cs
 * Author:  smvul
 * Purpose: Definition of the Class Model.Manager
 ***********************************************************************/

using Model;
using Newtonsoft.Json;
using System;

namespace WpfApp1.Model
{
   public class Manager : UserAccount
   {
        private Address OfficeAddress;
        private string OfficeNumber;

        [JsonConstructor]
        public Manager(string email, string name, string surname, string phoneNumber, string uniquePersonalNumber)
        {
            this.Email = email;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.UniquePersonalNumber = uniquePersonalNumber;
        }

        public Manager(string password, string uniquePersonalNumber)
        {
            this.Password = password;
            this.UniquePersonalNumber = uniquePersonalNumber;
        }

    }
}