// File:    PatientExaminationAppointmentRepository.cs
// Author:  Home
// Created: 10. април 2022. 19:27:31
// Purpose: Definition of Class PatientExaminationAppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections.Generic;

namespace Repo
{
   public class PatientExaminationAppointmentRepository
   {
        public PatientExaminationAppointmentFileHandler patientAppointmentFileHandler;
        public PatientExaminationAppointmentRepository(PatientExaminationAppointmentFileHandler patientAppointmentFileHandler)
        {
            this.patientAppointmentFileHandler = patientAppointmentFileHandler;
        }
        public List<PatientExaminationAppointment> GetAll()
        {
            return patientAppointmentFileHandler.Read();
        }
        public PatientExaminationAppointment GetById(string id)
        {
            List<PatientExaminationAppointment> list = GetAll();
           for(int i = 0; i < list.Count; i++)
            {
                PatientExaminationAppointment appointment = list[i];
                if(appointment.id == id)
                {
                    return appointment;
                }
            }
            return null;
        }

        public void Addd(PatientExaminationAppointment appointments)
        {
            List<PatientExaminationAppointment> list = GetAll();
            list.Add(appointments);
            patientAppointmentFileHandler.Write(list);
        }
      
      public void Delete(string id)
      {
            List<PatientExaminationAppointment> list = GetAll();
            for (int i = 0; i < list.Count; i++)
            {
               
                if (list[i].id == id)
                {
                    list.Remove(list[i]);
                }
            }

            patientAppointmentFileHandler.Write(list);
      }
   
      
      public void Update(PatientExaminationAppointment appointments)
      {
        List<PatientExaminationAppointment> list = GetAll();



      }



}
   }