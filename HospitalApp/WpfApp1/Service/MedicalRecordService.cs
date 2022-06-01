using System;
using System.Collections.Generic;
using Model;
using Repo;
using WpfApp1.Model;

namespace Service
{
    public class MedicalRecordService
    {
        public List<MedicalRecord> GetAll()
        {
            return medicalRecordRepository.GetAll();
        }

        public MedicalRecord GetByRegNum(string regNum)
        {
            return medicalRecordRepository.GetByRegNum(regNum);
        }

        public bool Add(MedicalRecord medicalRecord)
        {
            return medicalRecordRepository.Add(medicalRecord);
        }

        public bool Update(MedicalRecord medicalRecord)
        {
            return medicalRecordRepository.Update(medicalRecord);
        }

        public void Remove(string regNum)
        {
            medicalRecordRepository.Remove(regNum);
        }

        public MedicalRecordRepository medicalRecordRepository;

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

    }
}
