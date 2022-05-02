/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
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
      
      public Patient GetByUniquePersonalNumber(string uniquePersonalNumber)
      {
            return patientService.GetByUniquePersonalNumber(uniquePersonalNumber);
        }
      
      public void Add(Patient patient)
      {
            patientService.Add(patient);
        }
      
      public void Update(Patient patient)
      {
            patientService.Update(patient);
        }
      
      public void Remove(string id)
      {
            patientService.Remove(id);
        }

      public Service.PatientService patientService;

      public PatientController(PatientService patientService)
        {
            this.patientService = patientService;
        }

    }
}