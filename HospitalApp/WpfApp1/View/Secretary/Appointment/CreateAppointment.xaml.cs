using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Controller;
using FileHandler;
using Model;
using Repo;
using Service;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Type.ItemsSource = Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>();
            Patient.ItemsSource = FillComboBoxWithPatients();
            Room.ItemsSource = FillComboBoxWithRooms();
            Physician.ItemsSource = FillComboBoxWithPhysicians();

        }
        private List<Room> FillComboBoxWithRooms()
        {
            List<Room> roomsId = new List<Room>();
            foreach (Room room in RoomsWindow.roomController.GetAll())
            {
                roomsId.Add(room);
            }
            return roomsId;
        }
        private List<Patient> FillComboBoxWithPatients()
        {

            PatientFileHandler patientFileHandler = new PatientFileHandler();
            PatientRepository patientRepository = new PatientRepository(patientFileHandler);
            PatientService patientService = new PatientService(patientRepository);
            PatientController patientController = new PatientController(patientService);
            List<Patient> patients = patientController.GetAll();
            List<Patient> patientsUPN = new List<Patient>();

            foreach (Patient patient in patients)
            {
                patientsUPN.Add(patient);
            }
            return patientsUPN;
        }
    
        private List<Physician> FillComboBoxWithPhysicians()
        {
            PhysicianController physicianController = new PhysicianController();
            List <Physician> physicians = physicianController.GetAll();
            List<Physician> physiciansId = new List<Physician>();
            foreach (Physician physician in physicians)
            {    
                    physiciansId.Add(physician);   
            }
            return physiciansId;
        }

        private Patient patientBinding;
        public Patient PatientBinding
        {
            get
            {
                return patientBinding;
            }
            set
            {
                patientBinding = value;
                OnPropertyChanged("PatientBinding");
            }
        }

        private Physician physicianBinding;
        public Physician PhysicianBinding
        {
            get
            {
                return physicianBinding;
            }
            set
            {
                physicianBinding = value;
                OnPropertyChanged("PhysicianBinding");
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

        private DateTime dateOfAppointmentBinding;
        public DateTime DateOfAppointmentBinding
        {
            get
            {
                return dateOfAppointmentBinding;
            }
            set
            {
                dateOfAppointmentBinding = value;
                OnPropertyChanged("DateOfAppointmentBinding");
            }
        }

        private AppointmentType appointmentTypeBinding;
        public AppointmentType AppointmentTypeBinding
        {
            get
            {
                return appointmentTypeBinding;
            }
            set
            {
                appointmentTypeBinding = value;
                OnPropertyChanged("AppointmentTypeBinding");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {  
            Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            AppointmentFileHandler appointmentFileHandler = new AppointmentFileHandler();
            AppointmentRepository appointmentRepository = new AppointmentRepository(appointmentFileHandler);

            if (AppointmentWindow.appointmentController.Add(new Appointment(Physician.SelectedItem as Physician, Patient.SelectedItem as Patient, Room.SelectedItem as Room, DateOfAppointment.Value.Value, AppointmentTypeBinding)))
            {
                AppointmentWindow.appointmentWindowInstance.refreshContentOfGrid();
                Close();
            }
            else
            {
                MessageBox.Show("Appointment with that reg num already exists!", "Error");
            }
            
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Physician.SelectedItem != null && Patient.SelectedItem != null && Room.SelectedItem != null && DateOfAppointment != null)
            {
                e.CanExecute = true;
            }

        }      
    }
}