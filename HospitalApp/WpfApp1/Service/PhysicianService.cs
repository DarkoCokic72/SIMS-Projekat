/***********************************************************************
 * Module:  GetPatientInfo.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class GetPatientInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
using WpfApp1.Model;
using Repo;

namespace Service
{
    public class PhysicianService
    {
        public List<Physician> GetAll()
        {
            return physicianRepository.GetAll();
        }
        public bool UPNExists(string upn)
        {
            return physicianRepository.UPNExists(upn);
        }
        public bool EmailExists(string email)
        {
            return physicianRepository.EmailExists(email);
        }

        public Physician GetByLicenceID(string licenceID)
        {
            return physicianRepository.GetByLicenceID(licenceID);
        }

        public void Addd(Physician physician)
        {
            physicianRepository.Addd(physician);
        }

        public void Update(Physician physician)
        {
            physicianRepository.Update(physician);
        }

        public void Delete(string licenceID)
        {
            physicianRepository.Delete(licenceID);
        }


        public PhysicianRepository physicianRepository = new PhysicianRepository();

    }
}