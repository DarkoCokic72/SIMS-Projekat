using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Model;
using Controller;
using Syncfusion.Windows.Shared;
using WpfApp1.Model;
using Repo;

namespace WpfApp1.View.Patientt.PatientAppointments
{
    /// <summary>
    /// Interaction logic for NewAppointment.xaml
    /// </summary>
    public partial class NewAppointment : Window
    {
        public static Boolean addedAppointment = false;
        private PatientExaminationAppointment patientExaminationAppointment;
        string busy = "not busy";

       

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private string doctorBinding;
        public string DoctorBinding
        {
            get { return doctorBinding; }
            set
            {
                doctorBinding = value;
                OnPropertyChanged("DoctorBinding");

            }
        }
        private DateTime dateBinding;
        
        public DateTime DateBinding
        {
            get { return dateBinding; }
            set
            {
                dateBinding = value;
                OnPropertyChanged("DateBinding");

            }
        }
        //private DateTime timeBinding;
        //public DateTime TimeBinding
        //{
        //    get { return timeBinding; }
        //    set
        //    {
        //        timeBinding = value;
        //        OnPropertyChanged("TimeBinding");

        //    }
        //}

        private string idBinding;
        public string IdBinding
        {
            get
            {
                return idBinding;
            }
            set
            {
                idBinding = value;
                OnPropertyChanged("IdBinding");

            }
        }
        
        private string roomBinding;
        public string RoomBinding
        {
            get
            {
                return roomBinding;
            }
            set
            {
                roomBinding = value;
                OnPropertyChanged("RoomBinding");

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button Add = (Button)sender;
            if (Add.Content.Equals("Add"))
            {
                Appointments.patientAppointmentController.Addd(new PatientExaminationAppointment(IdBinding, DoctorBinding, DateBinding, RoomBinding));
                addedAppointment = true;
                if (addedAppointment == true)
                {
                    Appointments.AppointmentInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Appointment with that ID already exists!", "Error");
                }
            }



        }

 
        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IdBinding)  )
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void Doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (!string.IsNullOrEmpty((string)Room.SelectedItem) && busy != null && !string.IsNullOrEmpty((string)Doctor.SelectedItem)) 

            {
                Add.IsEnabled = true;
            }
    
        }

        private void Date_DateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldValue = e.OldValue;
            var newValue = e.NewValue;


        }
        public NewAppointment()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Date.DateTime = DateTime.Now;
            Date.MinDateTime = DateTime.Now;

            //Date.Pattern = DateTimePattern.CustomPattern;

            //DateBinding = DateTime.Now.ToString("MM/dd/yyyy");

            // DateBinding = Convert.ToDateTime(11 / 23 / 2022);
            //string s2 = DateBinding.ToString("MM/dd/yyyy");
            //DateBinding = Convert.ToDateTime(s2);
            //Date.Text = DateTime.Now.ToString();
            //Date=DateTime.Now.ToStrin
            RoomController roomController = new RoomController();
            List<Room> rooms = roomController.GetAll();
            List<string> roomsId = new List<string>();

            foreach (Room r in rooms)
            {
                roomsId.Add(r.Id);
            }

            Room.ItemsSource = roomsId;

            PhysicianController physicianController = new PhysicianController();
            List<Physician> physcicians = physicianController.GetAll();
            List<string> physicianName = new List<string>();

            foreach (Physician r in physcicians)
            {
                physicianName.Add(r.name + " " + r.surname);


            }

            Doctor.ItemsSource = physicianName;

            //PatientExaminationAppointmentController appointmentsCont = new PatientExaminationAppointmentController();
            //List<PatientExaminationAppointment> appointments = appointmentsCont.GetAll();
            //// List<DateTime> dates = new List<DateTime>();
            ////patientExaminationAppointment = Appointments.AppointmentInstance.getSelectedAppointments();
            //// = patientExaminationAppointment.datetimeOfAppointment;
            
            //foreach (PatientExaminationAppointment r in appointments)
            //{
            //    //dates.Add(r.datetimeOfAppointment);
            //    int results = DateTime.Compare(r.datetimeOfAppointment,DateBinding);
            //    if (results == 0)
            //    {
            //        MessageBox.Show("That time is busy", "Error");
            //        string busy = null;
            //        break;
            //    }
            //    int results1 = DateTime.Compare(r.datetimeOfAppointment.AddMinutes(15), DateBinding);
            //    if (results1 == 0)
            //    {
            //        MessageBox.Show("That time is busy", "Error");
            //        string busy = null;

            //    }
            //    else if (results1 > 0 && results < 0)
            //    {
            //        MessageBox.Show("That time is busy", "Error");
            //        string busy = null;

            //    }
            //    int results2 = DateTime.Compare(r.datetimeOfAppointment.AddMinutes(-15), DateBinding);
            //    if (results1 == 0)
            //    {
            //        MessageBox.Show("That time is busy", "Error");
            //        string busy = null;

            //    }
            //    else if (results2 < 0 && results > 0)
            //    {
            //        MessageBox.Show("That time is busy", "Error");
            //        string busy = null;

            //    }
                
            //}
            //for(int i = 0; i < dates.Count; i++)
            //{

            //    int results=DateTime.Compare()


            //}


            Add.IsEnabled = false;


        }
    }
}
