// File:    PatientExaminationAppointmentFileHandler.cs
// Author:  Home
// Created: 10. април 2022. 19:13:09
// Purpose: Definition of Class PatientExaminationAppointmentFileHandler

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileHandler
{
    public class PatientExaminationAppointmentFileHandler
    {
        private string path = @"..\..\Data\AppointmentsData.txt";

        public List<PatientExaminationAppointment> Read()
        {
            string patientExaminationAppointmentSerialized = System.IO.File.ReadAllText(path);
            List<PatientExaminationAppointment> appointments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PatientExaminationAppointment>>(patientExaminationAppointmentSerialized);
            return appointments;
        }

        public void Write(List<PatientExaminationAppointment> appointments)
        {

            string patientExaminationAppointmentSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(appointments);
            System.IO.File.WriteAllText(path, patientExaminationAppointmentSerialized);
        }

    }
}