// File:    PatientExaminationAppointment.cs
// Author:  Home
// Created: 10. април 2022. 18:40:51
// Purpose: Definition of Class PatientExaminationAppointment

using System;

namespace Model
{
    public class PatientExaminationAppointment
    {
        public string id { get; set; }
        public DateTime dateOfAppointment { get; set; }
     
        public DateTime timeOfAppointment { get; set; }

        public Room room { get; set; }
        public Physician physician { get; set; }




        public PatientExaminationAppointment(string id, Physician  physician, DateTime date, DateTime time,Room room)
        {
            this.physician = physician;
            this.dateOfAppointment = date;
            this.id = id;
            this.timeOfAppointment = time;
            this.room = room;
        }
    }
}