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
      private string email;
      private string password;
      private string name;
      private string surname;
      private string phoneNumber;
      private int uniquePersonalNumber;
      
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