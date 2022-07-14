/***********************************************************************
 * Module:  SecretaryFileHandler.cs
 * Author:  smvul
 * Purpose: Definition of the Class FileHandler.SecretaryFileHandler
 ***********************************************************************/
using Model;
using Newtonsoft.Json;
using System;

namespace WpfApp1.Model
{
    public class Secretary : UserAccount
    {
        private Address OfficeAddress;
        private string OfficeNumber;

        [JsonConstructor]
        public Secretary(string email, string name, string surname, string phoneNumber, string uniquePersonalNumber)
        {
            this.Email = email;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.UniquePersonalNumber = uniquePersonalNumber;
        }

        public Secretary(string password, string uniquePersonalNumber)
        {
            this.Password = password;
            this.UniquePersonalNumber = uniquePersonalNumber;
        }

    }
}