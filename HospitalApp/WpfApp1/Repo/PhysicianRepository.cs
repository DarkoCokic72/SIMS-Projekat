/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using FileHandler;
using Model;

namespace Repo
{
   public class PhysicianRepository
   {
      public List<Physician> GetAll()
      {
            return physicianFileHandler.Read();
        }

        public Physician GetByLicenceID(string licenceID)
        {
            List<Physician> List = GetAll();
            foreach (Physician r in List)
            {
                if (r.licenceID == licenceID)
                {

                    return r;

                }

            }
            return null;
        }

      public void Addd(Physician physician)
      {
            List<Physician> List = GetAll();
            List.Add(physician);
            physicianFileHandler.Write(List);
            //WpfApp1.CreatePatient.addedPatient = true;
        }
      
      public void Update(Physician physician)
      {
            List<Physician> List = GetAll();

            for (int i = 0; i < List.Count; i++)
            {

                if (List[i].uniquePersonalNumber.Equals(WpfApp1.PatientsWindow.patientsWindowInstance.getSelectedPatient().uniquePersonalNumber))
                {

                    List[i] = physician;
                    physicianFileHandler.Write(List);
                    //WpfApp1.PatientsEdit.editedPatient = true;
                    return;

                }
            }
        }
      
      public void Delete(string licenceID)
      {
            List<Physician> List = GetAll();

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].licenceID == licenceID)
                {
                    List.Remove(List[i]);

                }
            }
        }
      
      public FileHandler.PhysicianFileHandler physicianFileHandler=new PhysicianFileHandler();
   
   }
}