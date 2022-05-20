using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using WpfApp1.View.Patientt.PatientAppointments;



namespace WpfApp1.Model
{
    public class Physician : UserAccount
    {
        public string licenceID { get; set; } //class diagram
        public string type { get; set; }  //specijalista ili ne
        public PhysicianSpecialization specialization { get; set; } //koja je specijalizacija(opsta praksa,hirurg...)
        public Address office { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }

        public Physician(string licenceID, string type, PhysicianSpecialization specialization)
        {
            this.licenceID = licenceID;
            this.type = type;
            this.specialization = specialization;
        }

        public override bool Equals(object obj)
        {
            Physician physician = obj as Physician;

            if (physician == null) { return false; }

            return physician.licenceID == licenceID;
        }

    }
}
