using System;
using System.Collections.Generic;
using Model;
using Service;
using WpfApp1.Model;

namespace Controller
{
    public class AppointmentController
    {
        public List<Appointment> GetAll()
        {
            return appointmentService.GetAll();
        }

        public Appointment GetById(string id)
        {
            return appointmentService.GetById(id);
        }

        public List<Appointment> GetByPhysician(Physician physician, DateTime startDate, DateTime endDate)
        {
            return appointmentService.GetByPhysician(physician, startDate, endDate);
        }

        public bool Add(Appointment appointment)
        {
            return appointmentService.Add(appointment);
        }

        public bool Update(Appointment appointment)
        {
            return appointmentService.Update(appointment);
        }

        public void Remove(string id)
        {
            appointmentService.Remove(id);
        }

        public AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

    }
}
