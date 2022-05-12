using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using WpfApp1.View.PatientAppointments;



namespace WpfApp1.Model
{
    public class Physician : UserAccount
    {
        public string licenceID { get; set; } //class diagram
        public string type { get; set; }
        public string specialization { get; set; }
        public Address office { get; set; }

        public Physician(string licenceID, string type, string specialization)
        {
            this.licenceID = licenceID;
            this.type = type;
            this.specialization = specialization;
        }



    }
}
