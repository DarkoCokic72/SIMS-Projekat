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

namespace WpfApp1.View.PatientAppointments
{
    /// <summary>
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window

    {
        public static Boolean editedAppointement = false;
        private PatientExaminationAppointment patientExaminationAppointment;

        public EditAppointment()
        {

            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patientExaminationAppointment = Appointments.AppointmentsInstance.getSelectedAppointments();
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
        private DateTime timeBinding;
        public DateTime TimeBinding
        {
            get { return timeBinding; }
            set
            {
                timeBinding = value;
                OnPropertyChanged("TimeBinding");

            }
        }

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
        private Room roomBinding;
        public Room RoomBinding
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
            if (Add.Content.Equals("Edit"))
            {
                Appointments.patientAppointmentController.Update(new PatientExaminationAppointment(IdBinding, DoctorBinding, DateBinding, TimeBinding,RoomBinding));

                if (editedAppointement == true)
                {
                    Appointments.AppointmentsInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Cannot change ID", "Error");
                }
            }



        }

        private void Doctor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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
    }
}



