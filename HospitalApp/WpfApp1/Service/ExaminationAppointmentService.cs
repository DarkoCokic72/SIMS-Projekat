using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repo;

namespace Service
{
    public class ExaminationAppointmentService
    {
        public List<ExaminationAppointment> GetAll()
        {
            // throw new NotImplementedException();
            return examinationAppointmentRepository.GetAll();
        }

        public ExaminationAppointment GetById(string id)
        {
            //throw new NotImplementedException();
            return examinationAppointmentRepository.GetById(id);
        }

        public List<ExaminationAppointment> GetByPatientID(string patientID)
        {
            //throw new NotImplementedException();
            return examinationAppointmentRepository.GetByPatientId(patientID);
        }

        public List<ExaminationAppointment> GetByPhysicianID(string physicianID)
        {
            //throw new NotImplementedException();
            return examinationAppointmentRepository.GetByPhysicianID(physicianID);
        }

        public void Add(ExaminationAppointment appointment)
        {
            //throw new NotImplementedException();
           examinationAppointmentRepository.Add(appointment);
        }

        public void Update(ExaminationAppointment appointment)
        {
            //throw new NotImplementedException();

            examinationAppointmentRepository.Update(appointment);
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();
            examinationAppointmentRepository.Delete(id);
        }

        public Repo.ExaminationAppointmentRepository examinationAppointmentRepository = new ExaminationAppointmentRepository();

        

    }
}
