// File:    PatientExaminationAppointmentService.cs
// Author:  Home
// Created: 10. април 2022. 19:27:31
// Purpose: Definition of Class PatientExaminationAppointmentService

using Model;
using Repo;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PatientExaminationAppointmentService
    {
        public PatientExaminationAppointmentRepository patientAppointmentRepository;
        public PatientExaminationAppointmentService(PatientExaminationAppointmentRepository PatientAppointmentRepository)
        {
            this.patientAppointmentRepository = PatientAppointmentRepository;
        }
        public List<PatientExaminationAppointment> GetAll()
        {
            return patientAppointmentRepository.GetAll();
        }
        public PatientExaminationAppointment GetById(string id)
        {
            return patientAppointmentRepository.GetById(id);
        }
        public void Addd(PatientExaminationAppointment appointments)
        {
            patientAppointmentRepository.Addd(appointments);
        }

        public void Delete(string id)
        {
            patientAppointmentRepository.Delete(id);
        }

        public void Update(PatientExaminationAppointment appointments)
        {
            patientAppointmentRepository.Update(appointments);
        }



    }
}