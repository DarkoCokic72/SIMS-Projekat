using System;
using WpfApp1.Model;

namespace Model
{
    public class ExaminationAppointment
    {
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string Id { get; set; }
        

        public ExaminationAppointment(Physician physician, Patient patient, Room room, DateTime date, string id) 
        {
            this.Physician = physician;
            this.Patient = patient;
            this.Room = room;
            this.DateOfAppointment = date;
            this.Id = id;
        }

    }
}
