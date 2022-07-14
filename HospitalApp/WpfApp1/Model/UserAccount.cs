/***********************************************************************
 * Module:  UserAccount.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class UserAccount
 ***********************************************************************/

using System;

namespace Model
{
    public class UserAccount
    {
        private string password;
        public string Email { get; set; }
        public string Password { 
            get 
            {
                return password;
            }

            set 
            {
                if (value == null || value == string.Empty) 
                {
                    return;
                }

                password = value;
            }
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string UniquePersonalNumber { get; set; }

        public Address address;
        public Address Address
        {
            get
            {
                return address;
            }
            set
            {
                this.address = value;
            }
        }
    }
}