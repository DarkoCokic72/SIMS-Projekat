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
      
      public Patient GetByUniquePersonalNumber(string uniquePersonalNumber)
      {
            return patientRepository.GetByUniquePersonalNumber(uniquePersonalNumber);
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
      public bool PatientUPNExists(string upn)
      {
            return patientRepository.PatientUPNExists(upn);
      }
      public bool PatientEmailExists(string email)
      {
             return patientRepository.PatientEmailExists(email);
      }

      public PatientRepository patientRepository;

      public PatientService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

    }
}