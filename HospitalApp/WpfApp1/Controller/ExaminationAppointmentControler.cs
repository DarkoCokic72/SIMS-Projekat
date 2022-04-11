using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace WpfApp1.Controller
{
    public class ExaminationAppointmentControler
    {
        public List<ExaminationAppointment> GetAll()
        {
            //throw new NotImplementedException();
            return examinationAppointmentService.GetAll();
        }

        public ExaminationAppointment GetByID(string id)
        {
            //throw new NotImplementedException();
            return examinationAppointmentService.GetById(id);
        }

        public List<ExaminationAppointment> GetByPatientID(string patientID)
        {
            //throw new NotImplementedException();
            return examinationAppointmentService.GetByPatientID(patientID);
        }

        public void Add(ExaminationAppointment appointment)
        {
            //throw new NotImplementedException();
            examinationAppointmentService.Add(appointment);
        }

        public void Update(ExaminationAppointment appointment)
        {
            //throw new NotImplementedException();
            examinationAppointmentService.Update(appointment);
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();
            examinationAppointmentService.Delete(id);
        }

        public List<ExaminationAppointment> GetByPhysicianID(string physicianID)
        {
            //throw new NotImplementedException();
            return examinationAppointmentService.GetByPhysicianID(physicianID);
        }

        public Service.ExaminationAppointmentService examinationAppointmentService;

        public ExaminationAppointmentControler(ExaminationAppointmentService service)
        {
            this.examinationAppointmentService = service;
        }

    }
}
