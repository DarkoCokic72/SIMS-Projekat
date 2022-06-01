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
   public class MedicalRecordRepository
   {
      public List<MedicalRecord> GetAll()
      {
            return medicalRecordFileHandler.Read();
        }
      
      public MedicalRecord GetByRegNum(string regNum)
      {
            List<MedicalRecord> medicalRecordsList = GetAll();
            foreach (MedicalRecord medicalRecord in medicalRecordsList)
            {
                if (medicalRecord.RegNum == regNum)
                {
                    return medicalRecord;
                }
            }

            return null;
        }
      
      public bool Add(MedicalRecord medicalRecord)
      {
            List<MedicalRecord> medicalRecordList = GetAll();
            medicalRecordList.Add(medicalRecord);
            medicalRecordFileHandler.Save(medicalRecordList);
            return true;
            
        }
      
      public bool Update(MedicalRecord medicalRecord)
      {
            List<MedicalRecord> medicalRecordList = GetAll();

            /*if (WpfApp1.MedicalRecordWindow.medicalRecordWindowInstance.getSelectedMedicalRecord().RegNum != medicalRecord.RegNum)
            {
                for (int i = 0; i < medicalRecordList.Count; i++)
                {

                    if (medicalRecordList[i].RegNum.Equals(medicalRecord.RegNum))
                    {

                        WpfApp1.MedicalRecordEdit.editedMedicalRecord = false;
                        return;
                    }
                }
            }*/

            for (int i = 0; i < medicalRecordList.Count; i++)
            {

                if (medicalRecordList[i].RegNum.Equals(medicalRecord.RegNum))
                {
                    medicalRecordList[i] = medicalRecord;
                    medicalRecordFileHandler.Save(medicalRecordList);
                    return true;
                }
            }

            return false;
        }
      
      public void Remove(string regNum)
        {
            List<MedicalRecord> medicalRecordList = GetAll();

            for (int i = 0; i < medicalRecordList.Count; i++)
            {
                if (medicalRecordList[i].RegNum == regNum)
                {
                    medicalRecordList.Remove(medicalRecordList[i]);

                }
            }

            medicalRecordFileHandler.Save(medicalRecordList);
        }

        public MedicalRecordFileHandler medicalRecordFileHandler;

        public MedicalRecordRepository(MedicalRecordFileHandler fileHandler)
        {
            medicalRecordFileHandler = fileHandler;
        }

    }
}