/***********************************************************************
 * Module:  PatientFileHandler.cs
 * Author:  smvul
 * Purpose: Definition of the Class FileHandler.PatientFileHandler
 ***********************************************************************/

using System.Collections.Generic;
using Model;
using System;
using System.IO;
using System.Linq;

namespace FileHandler
{
   public class PatientFileHandler
   {
      
      public List<Patient> Read()
      {
            string patientsSerialized = System.IO.File.ReadAllText(path);
            List<Patient> patients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Patient>>(patientsSerialized);
            return patients;
        }
      
      public void Save(List<Patient> patients)
      {
            string patientsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(patients);
            System.IO.File.WriteAllText(path, patientsSerialized);
        }

        private string path = @"..\..\Data\Patients.txt";

    }
}