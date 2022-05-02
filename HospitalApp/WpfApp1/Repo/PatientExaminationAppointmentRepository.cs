// File:    PatientExaminationAppointmentRepository.cs
// Author:  Home
// Created: 10. април 2022. 19:27:31
// Purpose: Definition of Class PatientExaminationAppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using WpfApp1.View.PatientAppointments;


namespace Repo
{
    public class PatientExaminationAppointmentRepository
    {
        public PatientExaminationAppointmentFileHandler patientAppointmentFileHandler=new PatientExaminationAppointmentFileHandler();
       
        public List<PatientExaminationAppointment> GetAll()
        {
            return patientAppointmentFileHandler.Read();
        }
        public PatientExaminationAppointment a;
        public PatientExaminationAppointment GetById(string Id)
        {

            List<PatientExaminationAppointment> list = GetAll();
            foreach (PatientExaminationAppointment a in list)
            {

                if (a.id == Id)
                {
                    return a;
                }
            }
            return null;
        }

        public void Addd(PatientExaminationAppointment appointment)
        {
            if (GetById(appointment.id) == null)
            {
                List<PatientExaminationAppointment> list = GetAll();
                list.Add(appointment);
                patientAppointmentFileHandler.Write(list);
                NewAppointment.addedAppointment = true;
            }
            else
            {

                NewAppointment.addedAppointment = false;

            }
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
            //if (Appointments.AppointmentsInstance.getSelectedAppointments().id != appointments.id)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (list[i].id.Equals(appointments.id))
            //        {
            //            EditAppointment.editedAppointment = false;
            //            return;
            //        }
            //    }
            //}

                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i].id.Equals(Appointments.AppointmentsInstance.getSelectedAppointments().id))
                    {

                        list[i] = appointments;
                        patientAppointmentFileHandler.Write(list);
                        EditAppointment.editedAppointment = true;
                    }


                }
            


        }



    }
}