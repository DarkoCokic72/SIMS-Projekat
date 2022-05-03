using System.Collections.Generic;
using Model;
using System;
using System.IO;
using System.Linq;
using WpfApp1.Model;

namespace FileHandler
{
    public class MedicalRecordFileHandler
    {

        public List<MedicalRecord> Read()
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<MedicalRecord>();
            }

            string medicalRecordsSerialized = System.IO.File.ReadAllText(path);
            List<MedicalRecord> medicalRecords = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MedicalRecord>>(medicalRecordsSerialized);
            return medicalRecords;
        }

        public void Save(List<MedicalRecord> medicalRecords)
        {
            string medicalRecordsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(medicalRecords);
            System.IO.File.WriteAllText(path, medicalRecordsSerialized);
        }

        private string path = @"..\..\Data\MedicalRecords.txt";
    }
}
