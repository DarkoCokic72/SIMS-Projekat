// File:    PatientExaminationAppointmentController.cs
// Author:  Home
// Created: 10. април 2022. 19:27:31
// Purpose: Definition of Class PatientExaminationAppointmentController

using Model;
using Service;
using System;
using System.Collections.Generic;
using WpfApp1.Model;

namespace Controller
{
   public class PatientExaminationAppointmentController
   {
      public List<PatientExaminationAppointment> GetAll()
      {
        return patientAppointmentService.GetAll();
      }
      
      public void Addd(PatientExaminationAppointment appointments)
      {
            patientAppointmentService.Addd(appointments);
      }
      
      public void Delete(string id)
      {
            patientAppointmentService.Delete(id);
      }
      
      public void Update(PatientExaminationAppointment appointments)
      {
            patientAppointmentService.Update(appointments);
      }
      
      public PatientExaminationAppointment GetById(string id)
      {
            return patientAppointmentService.GetById(id);
      }
      public List<System.DateTime> getAvailableDate(string id)
      {
            return patientAppointmentService.getAvailableDate(id);
      }
        public Service.PatientExaminationAppointmentService patientAppointmentService=new PatientExaminationAppointmentService();

       
    }
}