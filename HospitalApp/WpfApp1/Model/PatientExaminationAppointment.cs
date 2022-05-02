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
        public DateTime datetimeOfAppointment { get; set; }  //class diagram
      
     
       
        public string roomId { get; set; }
        public Room room { get; set; }
        public Physician physician { get; set; }
       




        public PatientExaminationAppointment(string id, Physician  physician, DateTime date, string roomId )
        {
            this.physician = physician;
            this.datetimeOfAppointment = date;
            this.id = id;
           
            this.roomId =roomId;
        }
    }
}