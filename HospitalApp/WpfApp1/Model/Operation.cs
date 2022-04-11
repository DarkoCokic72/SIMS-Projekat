using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Model
{
    public class Operation
    {
        public SpecialisedPhysician SpecialisedPhysician { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateOfOperation { get; set; }
        private Room OperationRoom { get; set; }
        public string Id { get; set; }

        public Operation(SpecialisedPhysician physician, Patient patient, DateTime date, Room room, string id) {
            this.SpecialisedPhysician = physician;
            this.Patient = patient;
            this.DateOfOperation = date;
            this.Id = id;
        }

    }
}
