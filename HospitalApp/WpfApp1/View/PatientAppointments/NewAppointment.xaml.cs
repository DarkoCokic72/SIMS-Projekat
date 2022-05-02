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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using Controller;
using Syncfusion.Windows.Shared;
using System.Globalization;

namespace WpfApp1.View.PatientAppointments
{
    /// <summary>
    /// Interaction logic for NewAppointment.xaml
    /// </summary>
    public partial class NewAppointment : Window
    {
        public static Boolean addedAppointment = false;
        
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
            Add.IsEnabled = false;


        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private Physician doctorBinding;
        public Physician DoctorBinding
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

                if (addedAppointment == true)
                {
                    Appointments.AppointmentsInstance.refreshContentOfGrid();
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
            if (string.IsNullOrEmpty(IdBinding))
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
            Physician selectedPerson = Doctor.SelectedItem as Physician;
            MessageBox.Show(selectedPerson.name + selectedPerson.surname, "Doctor is selected");
        }

        private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Room.SelectedItem))
            {
                Add.IsEnabled = true;
            }
    
        }

        private void Date_DateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldValue = e.OldValue;
            var newValue = e.NewValue;
        }
    }
}
