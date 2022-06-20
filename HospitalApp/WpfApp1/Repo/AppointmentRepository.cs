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

        public int AppointmentID()
        {
            List<Appointment> appointmentsList = GetAll();
            int maxID = 0;
            
            foreach (Appointment appointment in appointmentsList)
            {
                if (int.Parse(appointment.Id) > maxID) 
                {
                    maxID = int.Parse(appointment.Id);
                }
            }

            return maxID + 1;
        }

        public List<Appointment> GetByPhysician(Physician physician, DateTime startDate, DateTime endDate)
        {
            List<Appointment> appointments = GetAll();
            List<Appointment> appointmentsByPhysician = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Physician.licenceID == physician.licenceID && appointment.DateOfAppointment >= startDate && appointment.DateOfAppointment <= endDate)
                {
                    appointmentsByPhysician.Add(appointment);
                }
            }

            return appointmentsByPhysician;
        }
        public bool PhysicianIsBusy(Physician physician, DateTime date)
        {
            List<Appointment> appointments = GetAll();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Physician.licenceID == physician.licenceID && appointment.DateOfAppointment == date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool RoomIsBusy(Room room, DateTime date)
        {
            List<Appointment> appointments = GetAll();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room.Id == room.Id && appointment.DateOfAppointment == date)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Add(Appointment appointment)
        {
            List<Appointment> appointmentsList = GetAll();
            appointment.Id = AppointmentID().ToString();
            appointmentsList.Add(appointment);
            appointmentFileHandler.Save(appointmentsList);
            return true;
        }

        public bool Update(Appointment appointment)
        {
            List<Appointment> appointmentList = GetAll();

            for (int i = 0; i < appointmentList.Count; i++)
            {
                if (appointmentList[i].Id.Equals(appointment.Id))
                {
                    appointmentList[i] = appointment;
                    appointmentFileHandler.Save(appointmentList);
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
