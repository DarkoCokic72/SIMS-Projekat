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

        public void Add(MedicalRecord medicalRecord)
        {
            medicalRecordRepository.Add(medicalRecord);
        }

        public void Update(MedicalRecord medicalRecord)
        {
            medicalRecordRepository.Update(medicalRecord);
        }

        public void Remove(string regNum)
        {
            medicalRecordRepository.Remove(regNum);
        }

        public Repo.MedicalRecordRepository medicalRecordRepository;

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

    }
}
