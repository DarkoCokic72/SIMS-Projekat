using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Model
{
    public class ExaminationAppointment
    {
        private Physician Physician { get; set; }
        private Patient Patient { get; set; }
        private DateTime DateOfAppointment { get; set; }
        public string Id { get; set; }

        public ExaminationAppointment(Physician physician, Patient patient, DateTime date, string id) 
        {
            this.Physician = physician;
            this.Patient = patient;
            this.DateOfAppointment = date;
            this.Id = id;
        }

    }
}
