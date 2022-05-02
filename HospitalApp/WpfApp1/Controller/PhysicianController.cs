/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/


using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
   public class PhysicianController
   {
      public List<Physician> GetAll()
      {
            return physicianService.GetAll();
      }
      
      public Physician GetByLicenceID(string licenceID)
      {
            return physicianService.GetByLicenceID(licenceID);
        }
      
      public void Addd(Physician physician)
      {
            physicianService.Addd(physician);
        }

        public void Update(Physician physician)
      {
            physicianService.Update(physician);
        }
      
      public void Delete(string licenceID)
      {
            physicianService.Delete(licenceID);
        }
      
      public Service.PhysicianService physicianService=new PhysicianService();

    }
}