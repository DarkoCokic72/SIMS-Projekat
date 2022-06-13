/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repo;
using WpfApp1.Model;

namespace Service
{
   public class PatientService
   {
      public List<Patient> GetAll()
      {
            return patientRepository.GetAll();
      }
        public List<Patient> IsGuestAccount()
        {
            return patientRepository.IsGuestAccount();
        }

        public Patient GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
            return patientRepository.GetByUniquePersonalNumber(uniquePersonalNumber);
        }

        public bool UPNExists(string upn)
        {
            return patientRepository.UPNExists(upn);
        }
        public bool EmailExists(string email)
        {
            return patientRepository.EmailExists(email);
        }

        public bool Add(Patient patient)
      {
            return patientRepository.Add(patient);
      }
      
      public bool Update(Patient patient)
        {
            return patientRepository.Update(patient);
        }
      
      public void Remove(string id)
      {
            patientRepository.Remove(id);
      }

      public PatientRepository patientRepository;

      public PatientService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

    }
}