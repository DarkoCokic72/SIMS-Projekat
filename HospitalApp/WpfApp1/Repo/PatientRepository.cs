/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using FileHandler;
using Model;
using WpfApp1.Model;

namespace Repo
{
   public class PatientRepository
   {
      public List<Patient> GetAll()
      {
            return patientFileHandler.Read();
        }
      
      public Patient GetByUniquePersonalNumber(string uniquePersonalNumber)
      {
            List<Patient> patientsList = GetAll();
            foreach (Patient patient in patientsList)
            {
                if (patient.UniquePersonalNumber == uniquePersonalNumber)
                {

                    return patient;

                }

            }

            return null;
        }
      
      public void Add(Patient patient)
      {
            List<Patient> patientList = GetAll();
            patientList.Add(patient);
            patientFileHandler.Save(patientList);
            WpfApp1.CreatePatient.addedPatient = true;
            
        }
      
      public void Update(Patient patient)
      {
            List<Patient> patientList = GetAll();

            if (WpfApp1.PatientsWindow.patientsWindowInstance.getSelectedPatient().UniquePersonalNumber != patient.UniquePersonalNumber)
            {
                for (int i = 0; i < patientList.Count; i++)
                {

                    if (patientList[i].UniquePersonalNumber.Equals(patient.UniquePersonalNumber))
                    {

                        WpfApp1.PatientsEdit.editedPatient = false;
                        return;
                    }
                }
            }

            for (int i = 0; i < patientList.Count; i++)
            {

                if (patientList[i].UniquePersonalNumber.Equals(WpfApp1.PatientsWindow.patientsWindowInstance.getSelectedPatient().UniquePersonalNumber))
                {

                    patientList[i] = patient;
                    patientFileHandler.Save(patientList);
                    WpfApp1.PatientsEdit.editedPatient = true;
                    return;

                }
            }
        }
      
      public void Remove(string id)
        {
            List<Patient> patientList = GetAll();

            for (int i = 0; i < patientList.Count; i++)
            {
                if (patientList[i].UniquePersonalNumber == id)
                {
                    patientList.Remove(patientList[i]);

                }
            }

            patientFileHandler.Save(patientList);
        }

        public FileHandler.PatientFileHandler patientFileHandler;

        public PatientRepository(PatientFileHandler fileHandler)
        {
            patientFileHandler = fileHandler;
        }

    }
}