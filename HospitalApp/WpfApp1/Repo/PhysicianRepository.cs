
/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace Repo
{
   public class PhysicianRepository
   {
      public List<Physician> GetAll()
      {
            return physicianFileHandler.Read();
        }

        public bool UPNExists(string upn)
        {
            foreach (Physician physician in GetAll())
            {
                if (physician.UniquePersonalNumber == upn) return true;
            }
            return false;
        }
        public bool EmailExists(string email)
        {
            foreach (Physician physician in GetAll())
            {
                if (physician.Email == email) return true;
            }
            return false;
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
            physicianFileHandler.Save(List);
            //WpfApp1.CreatePatient.addedPatient = true;
        }
      
      public void Update(Physician physician)
      {
            List<Physician> List = GetAll();

            for (int i = 0; i < List.Count; i++)
            {

                if (List[i].UniquePersonalNumber.Equals(WpfApp1.PatientsWindow.patientsWindowInstance.getSelectedPatient().UniquePersonalNumber))
                {

                    List[i] = physician;
                    physicianFileHandler.Save(List);
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
      
      public WpfApp1.FileHandler.PhysicianFileHandler physicianFileHandler=new PhysicianFileHandler();

    }
}
