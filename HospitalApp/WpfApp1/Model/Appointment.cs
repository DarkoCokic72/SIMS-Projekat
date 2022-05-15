using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Model
{
    public class Appointment
    {
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string Id { get; set; }
        public AppointmentType Type { get; set; }


        public Appointment(Physician physician, Patient patient, Room room, DateTime date, string id, AppointmentType type)
        {
            this.Physician = physician;
            this.Patient = patient;
            this.Room = room;
            this.DateOfAppointment = date;
            this.Id = id;
            this.Type = type;
        }

    }
}
