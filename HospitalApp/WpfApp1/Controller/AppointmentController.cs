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

        public void Add(Appointment appointment)
        {
            appointmentService.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            appointmentService.Update(appointment);
        }

        public void Remove(string id)
        {
            appointmentService.Remove(id);
        }

        public Service.AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

    }
}
