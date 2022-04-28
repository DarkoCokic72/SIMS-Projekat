// File:    PatientExaminationAppointment.cs
// Author:  Home
// Created: 10. април 2022. 18:40:51
// Purpose: Definition of Class PatientExaminationAppointment


using System;

namespace Model
{
    public class PatientExaminationAppointment
    {
        public Physician doctor { get; set; } //dodaj na klas diagram!!!!!
        public DateTime dateOfAppointment { get; set; } //dodaj na klas diagram!!!!!
        public DateTime timeOfAppointment { get; set; }   //dodaj na klas diagram!!!!!




        public string id { get; set; } //dodaj na klas diagram!!!!!


        public PatientExaminationAppointment(string id, Physician doctor, DateTime date, DateTime time)
        {
            this.doctor = doctor;
            this.dateOfAppointment = date;
            this.id = id;
            this.timeOfAppointment = time;
        }
    }
}