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
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string uniquePersonalNumber { get; set; }

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