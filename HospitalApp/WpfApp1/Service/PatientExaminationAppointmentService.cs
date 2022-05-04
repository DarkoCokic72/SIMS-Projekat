// File:    PatientExaminationAppointmentService.cs
// Author:  Home
// Created: 10. април 2022. 19:27:31
// Purpose: Definition of Class PatientExaminationAppointmentService

using Model;
using Repo;
using System;
using System.Collections.Generic;

using System.Linq;


namespace Service
{
    public class PatientExaminationAppointmentService
    {
        public PatientExaminationAppointmentRepository patientAppointmentRepository= new PatientExaminationAppointmentRepository(); 
        public RoomRepository roomRepository = new RoomRepository();

       
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

        public List<System.DateTime> getAvailableDate(string id)
        {
            List<System.DateTime> dates = new List<DateTime>();

            List<PatientExaminationAppointment> appointment = patientExaminationAppointmentRepository.GetAll();
            foreach (PatientExaminationAppointment e in appointment)
            {
                if (e.id == id)
                {
                    int result = DateTime.Compare(DateTime.Now.AddDays(1), e.datetimeOfAppointment);
                    int result1 = DateTime.Compare(DateTime.Now, e.datetimeOfAppointment.AddDays(-4));
                    int result2 = DateTime.Compare(DateTime.Now, e.datetimeOfAppointment.AddDays(-3));
                    int result3 = DateTime.Compare(DateTime.Now, e.datetimeOfAppointment.AddDays(-2));
                    int result4 = DateTime.Compare(DateTime.Now, e.datetimeOfAppointment.AddDays(-1));
                    if (result < 0)
                    {
                        if (result1 <=0)
                        {
                            
                            
                            for (int i = 5; i <= 365; i++)
                                dates.Add(e.datetimeOfAppointment.AddDays(i));
                            for (int j = -365; j > -4; j++)
                                dates.Add(e.datetimeOfAppointment.AddDays(j));
                        }
                        else if (result2<=0 && result1>0)
                        {
                            for (int i = 5; i <= 365; i++)
                                dates.Add(e.datetimeOfAppointment.AddDays(i));
                            for (int j = -365; j > -3; j++)
                                dates.Add(e.datetimeOfAppointment.AddDays(j));
                        }
                        else if (result3 <= 0 && result2 > 0)
                        {
                            for (int i = 5; i <= 365; i++)
                                dates.Add(e.datetimeOfAppointment.AddDays(i));
                            for (int j = -365; j > -2; j++)
                                dates.Add(e.datetimeOfAppointment.AddDays(j));
                        }
                        else if (result4 <= 0 && result3 > 0)
                        {
                            for (int i = 5; i <= 365; i++)
                                dates.Add(e.datetimeOfAppointment.AddDays(i));
                            for (int j = -365; j > -1; j++)
                                dates.Add(e.datetimeOfAppointment.AddDays(j));
                        }
                    }


                }

            }
            dates.Distinct();
            return dates; 
        }
        public Repo.PatientExaminationAppointmentRepository patientExaminationAppointmentRepository = new PatientExaminationAppointmentRepository();


    }
}