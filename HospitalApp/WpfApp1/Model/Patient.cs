/***********************************************************************
 * Module:  Patient.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using Model;
using System;
using WpfApp1.Model;

namespace WpfApp1.Model
{
   public class Patient : UserAccount
   {
       public DateTime DateOfBirth { get; set; }
       public BloodGroup BloodGroup { get; set; }
       public bool IsGuestAccount { get; set; }

        public string FullName 
       {
           get { return Name + " " + Surname; }
       }

        public Patient(String email, String name, String surname, String phoneNumber, String uniqueuniquePersonalNumber, DateTime dateOfBirth, BloodGroup bloodGroup)
        {
            this.Email = email;
            //this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.UniquePersonalNumber = uniqueuniquePersonalNumber;
            this.DateOfBirth = dateOfBirth;
            this.BloodGroup = bloodGroup;
        }
        public override bool Equals(object obj)
        {
            Patient patient = obj as Patient;

            if (patient == null) 
            {
                return false;
            }

            return patient.UniquePersonalNumber == UniquePersonalNumber;
        }

    }
}