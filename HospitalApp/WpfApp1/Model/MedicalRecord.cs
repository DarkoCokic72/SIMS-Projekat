using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp1.Model;

namespace Model
{
    public class MedicalRecord
    {
        public string RegNum { get; set; }
        public Patient Patient { get; set; }
        public string Allergens { get; set; }

        public MedicalRecord(Patient patient, string allergens)
        {
            this.Patient = patient;
            this.Allergens = allergens;
        }

    }
}
