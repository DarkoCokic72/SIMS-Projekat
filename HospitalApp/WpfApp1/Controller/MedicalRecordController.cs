using System;
using System.Collections.Generic;
using Model;
using Service;
using WpfApp1.Model;

namespace Controller
{
    public class MedicalRecordController
    {
        public List<MedicalRecord> GetAll()
        {
            return medicalRecordService.GetAll();
        }

        public MedicalRecord GetByRegNum(string regNum)
        {
            return medicalRecordService.GetByRegNum(regNum);
        }
        public MedicalRecord GetByPatient(Patient patient)
        {
            return medicalRecordService.GetByPatient(patient);
        }

        public bool Add(MedicalRecord medicalRecord)
        {
            return medicalRecordService.Add(medicalRecord);
        }

        public bool Update(MedicalRecord medicalRecord)
        {
           return medicalRecordService.Update(medicalRecord);
        }

        public void Remove(string regNum)
        {
            medicalRecordService.Remove(regNum);
        }

        public MedicalRecordService medicalRecordService;

        public MedicalRecordController(MedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
        }

    }
}
