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
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string UniquePersonalNumber { get; set; }

        public Address address;

        /// <summary>
        /// Property for Address
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
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