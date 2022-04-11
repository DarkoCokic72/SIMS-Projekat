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
        public PatientExaminationAppointmentRepository PatientAppointmentRepository;
        public PatientExaminationAppointmentService(PatientExaminationAppointmentRepository PatientAppointmentRepository)
        {
            this.PatientAppointmentRepository = PatientAppointmentRepository;
        }
      public List<PatientExaminationAppointment> GetAll()
      {
          return  PatientAppointmentRepository.GetAll();
      }
      public PatientExaminationAppointment GetById(string id)
      {
          return PatientAppointmentRepository.GetById(id);
      }
        public void Addd(PatientExaminationAppointment appointments)
      {
            PatientAppointmentRepository.Addd(appointments);
      }
      
      public void Delete(string id)
      {
            PatientAppointmentRepository.Delete(id);    
      }
      
      public void Update(PatientExaminationAppointment appointments)
      {
            PatientAppointmentRepository.Update(appointments);
      }
      

   
   }
}