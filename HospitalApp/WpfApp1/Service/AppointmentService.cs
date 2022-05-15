using System;
using System.Collections.Generic;
using Model;
using Repo;
using WpfApp1.Model;

namespace Service
{
    public class AppointmentService
    {
        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public Appointment GetById(string id)
        {
            return appointmentRepository.GetById(id);
        }

        public void Add(Appointment appointment)
        {
            appointmentRepository.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            appointmentRepository.Update(appointment);
        }

        public void Remove(string id)
        {
            appointmentRepository.Remove(id);
        }

        public Repo.AppointmentRepository appointmentRepository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

    }
}
