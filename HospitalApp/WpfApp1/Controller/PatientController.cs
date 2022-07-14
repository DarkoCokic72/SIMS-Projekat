/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repo;
using Service;
using WpfApp1.Model;

namespace Controller
{
   public class PatientController
   {
      public List<Patient> GetAll()
      {
            return patientService.GetAll();
      }
        public List<Patient> IsGuestAccount()
        {
            return patientService.IsGuestAccount();
        }
        public bool EmailExists(string email)
        {
            return patientService.EmailExists(email);
        }
        public bool UPNExists(string upn)
        {
            return patientService.UPNExists(upn);
        }

        /*
        public Patient GetByUniquePersonalNumber(string uniquePersonalNumber)
        {
              return patientService.GetByUniquePersonalNumber(uniquePersonalNumber);
        }
        */
        public bool Add(Patient patient)
      {
           return patientService.Add(patient);
      }
      
      public bool Update(Patient patient)
      {
            return patientService.Update(patient);
      }
      
      public void Remove(string id)
      {
            patientService.Remove(id);
      }

      public PatientService patientService;

      public PatientController(PatientService patientService)
      {
            this.patientService = patientService;
      }
    }
}