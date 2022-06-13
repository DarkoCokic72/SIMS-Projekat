/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using FileHandler;
using Model;
using WpfApp1;
using WpfApp1.Model;

namespace Repo
{
   public class PatientRepository
   {
      public List<Patient> GetAll()
      {
            return patientFileHandler.Read();
      }
        public List<Patient> IsGuestAccount()
        {
            List<Patient> patients = GetAll();
            List<Patient> isGuestAccount = new List<Patient>();
            foreach (Patient patient in patients)
            {
                if (!patient.IsGuestAccount)
                {
                    isGuestAccount.Add(patient);
                }
            }
            return isGuestAccount;
        }

        public bool UPNExists(string upn)
        {
            foreach (Patient patient in GetAll())
            {
                if (patient.UniquePersonalNumber == upn) return true;
            }
            return false;
        }
        public bool EmailExists(string email)
        {
            foreach (Patient patient in GetAll())
            {
                if (patient.Email == email) return true;
            }
            return false;
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
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public bool Add(Patient patient)
        {
            List<Patient> patientList = GetAll();
            patient.IsGuestAccount = false;
            patient.Password = CreatePassword(15);
            patientList.Add(patient);
            patientFileHandler.Save(patientList);
            return true;
        }
      
      public bool Update(Patient patient)
      {
            List<Patient> patientList = GetAll();

            for (int i = 0; i < patientList.Count; i++)
            {

                if (patientList[i].UniquePersonalNumber.Equals(PatientsWindow.patientsWindowInstance.getSelectedPatient().UniquePersonalNumber))
                {
                    patientList[i] = patient;
                    patientFileHandler.Save(patientList);
                    return true;
                }
            }
            return false;
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