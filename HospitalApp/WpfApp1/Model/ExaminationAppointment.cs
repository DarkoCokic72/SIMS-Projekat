using System;

namespace Model
{
    public class ExaminationAppointment
    {
        public string Physician { get; set; }
        public string Patient { get; set; }
        public string Room { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string Id { get; set; }
        

        public ExaminationAppointment(string physician, string patient, string room, DateTime date, string id) 
        {
            this.Physician = physician;
            this.Patient = patient;
            this.Room = room;
            this.DateOfAppointment = date;
            this.Id = id;
        }

    }
}
