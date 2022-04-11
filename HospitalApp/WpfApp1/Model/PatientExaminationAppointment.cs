// File:    PatientExaminationAppointment.cs
// Author:  Home
// Created: 10. април 2022. 18:40:51
// Purpose: Definition of Class PatientExaminationAppointment

using System;

namespace Model
{
    public class PatientExaminationAppointment
    {
        private Physician physician { get; set; }
        private DateTime dateOfAppointment { get; set; }
        public string id { get; set; }


        public PatientExaminationAppointment()
        {
            this.physician=physician;
            this.dateOfAppointment=dateOfAppointment;
            this.id=id;
        }
    }
}