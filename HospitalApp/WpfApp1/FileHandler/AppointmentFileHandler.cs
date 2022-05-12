using System.Collections.Generic;
using Model;
using System;
using System.IO;
using System.Linq;
using WpfApp1.Model;

namespace FileHandler
{
    public class AppointmentFileHandler
    {

        public List<Appointment> Read()
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<Appointment>();
            }

            string appointmentSerialized = System.IO.File.ReadAllText(path);
            List<Appointment> appointment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Appointment>>(appointmentSerialized);
            return appointment;
        }

        public void Save(List<Appointment> appointment)
        {
            string appointmentSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(appointment);
            System.IO.File.WriteAllText(path, appointmentSerialized);
        }

        private string path = @"..\..\Data\Appointment.txt";
    }
}
