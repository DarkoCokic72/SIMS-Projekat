/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repo;

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
      
      public void Add(Patient patient)
      {
            patientRepository.Add(patient);
        }
      
      public void Update(Patient patient)
      {
            patientRepository.Update(patient);
        }
      
      public void Remove(string id)
      {
            patientRepository.Remove(id);
        }

      public Repo.PatientRepository patientRepository;

      public PatientService(PatientRepository PatientRepository)
        {

            this.patientRepository = patientRepository;

        }

    }
}