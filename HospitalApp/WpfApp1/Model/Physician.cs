using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using WpfApp1.View.PatientAppointments;



namespace Model
{
    public class Physician : UserAccount
    {
        public string licenceID { get; set; } //class diagram
        public Address office { get; set; }




       
    }
}
