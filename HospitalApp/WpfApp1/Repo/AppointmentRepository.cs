using System;
using System.Collections.Generic;
using FileHandler;
using Model;
using WpfApp1.Model;

namespace Repo
{
    public class AppointmentRepository
    {
        public List<Appointment> GetAll()
        {
            return appointmentFileHandler.Read();
        }

        public Appointment GetById(string id)
        {
            List<Appointment> appointmentsList = GetAll();
            foreach (Appointment appointment in appointmentsList)
            {
                if (appointment.Id == id)
                {
                    return appointment;
                }
            }
            return null;
        }

        public bool Add(Appointment appointment)
        {
            List<Appointment> appointmentsList = GetAll();
            appointmentsList.Add(appointment);
            appointmentFileHandler.Save(appointmentsList);
            return true;
        }

        public bool Update(Appointment appointment)
        {
            List<Appointment> appointmentsList = GetAll();

            /*
            for (int i = 0; i < appointmentsList.Count; i++)
            {

                if (appointmentsList[i].Id.Equals(appointment.Id))
                {
                    WpfApp1.AppointmentEdit.editedAppointment = false;
                }
            }*/
            
            for (int i = 0; i < appointmentsList.Count; i++)
            {
                if (appointmentsList[i].Id.Equals(appointment.Id))
                {

                    appointmentsList[i] = appointment;
                    appointmentFileHandler.Save(appointmentsList);
                    return true;
                }
            }

            return false;
        }

        public void Remove(string id)
        {
            List<Appointment> appointmentsList = GetAll();

            for (int i = 0; i < appointmentsList.Count; i++)
            {
                if (appointmentsList[i].Id == id)
                {
                    appointmentsList.Remove(appointmentsList[i]);

                }
            }

            appointmentFileHandler.Save(appointmentsList);
        }

        public AppointmentFileHandler appointmentFileHandler;

        public AppointmentRepository(AppointmentFileHandler fileHandler)
        {
            appointmentFileHandler = fileHandler;
        }

    }
}
