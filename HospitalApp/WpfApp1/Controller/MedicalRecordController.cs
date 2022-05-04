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

        public void Add(MedicalRecord medicalRecord)
        {
            medicalRecordService.Add(medicalRecord);
        }

        public void Update(MedicalRecord medicalRecord)
        {
            medicalRecordService.Update(medicalRecord);
        }

        public void Remove(string regNum)
        {
            medicalRecordService.Remove(regNum);
        }

        public Service.MedicalRecordService medicalRecordService;

        public MedicalRecordController(MedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
        }

    }
}
