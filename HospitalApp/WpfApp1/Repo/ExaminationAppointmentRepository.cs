using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using FileHandler;
using WpfApp1.FileHandler;

namespace Repo
{
    public class ExaminationAppointmentRepository
    {
        public List<ExaminationAppointment> GetAll()
        {
            // throw new NotImplementedException();
            return examinationAppointmentFileHandler.Read();
        }

        public ExaminationAppointment GetById(string id)
        {
            //throw new NotImplementedException();

            List<ExaminationAppointment> listOfExaminations = GetAll();
            foreach (ExaminationAppointment e in listOfExaminations) {
                if (e.Id.Equals(id)) {
                    return e;
                }
            }

            return null;
        }

        public void Add(ExaminationAppointment appointment)
        {
            //throw new NotImplementedException();
            if (GetById(appointment.Id) == null) {

                List<ExaminationAppointment> listOfExaminations = GetAll();
                listOfExaminations.Add(appointment);
                examinationAppointmentFileHandler.Write(listOfExaminations);
                WpfApp1.View.Physician.ExaminationAppointments.CreateAppointmentWindow.appointmentAdded = true;
            } else
            {
                WpfApp1.View.Physician.ExaminationAppointments.CreateAppointmentWindow.appointmentAdded = false;
            }
        }

        public void Update(ExaminationAppointment Appointment)
        {
            //throw new NotImplementedException();
            List<ExaminationAppointment> listOfAppointments = GetAll();

            for(int i = 0; i < listOfAppointments.Count; i++)
            {
                if (listOfAppointments[i].Id.Equals(Appointment.Id))
                {
                    listOfAppointments[i] = Appointment;
                    examinationAppointmentFileHandler.Write(listOfAppointments);
                    WpfApp1.View.Physiciann.ExaminationAppointments.EditAppointmentWindow.appointmentEdited = true;
                }
            }
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();

            List<ExaminationAppointment> listOfExaminations = GetAll();
            for(int i = 0; i < listOfExaminations.Count; i++)
            {
                if (listOfExaminations[i].Id.Equals(id))
                {
                    listOfExaminations.Remove(listOfExaminations[i]);
                }
            }

            examinationAppointmentFileHandler.Write(listOfExaminations);
        }

        public List<ExaminationAppointment> GetByPatientId(string patientID)
        {
            throw new NotImplementedException();
        } 

        public List<ExaminationAppointment> GetByPhysicianID(string physicianID)
        {
            throw new NotImplementedException();
        }

        public WpfApp1.FileHandler.ExaminationAppointmentFileHandler examinationAppointmentFileHandler = new WpfApp1.FileHandler.ExaminationAppointmentFileHandler();

        

    }
}
