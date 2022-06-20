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

    public partial class CreateUrgentAppointment : Window
    {
        public CreateUrgentAppointment()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Type.ItemsSource = Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>();
            Specialization.ItemsSource = Enum.GetValues(typeof(PhysicianSpecialization)).Cast<PhysicianSpecialization>();
            Patient.ItemsSource = ComboBoxPatients();

        }
        private List<Patient> ComboBoxPatients()
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

        private PhysicianSpecialization specializationBinding;
        public PhysicianSpecialization SpecializationBinding
        {
            get
            {
                return specializationBinding;
            }
            set
            {
                specializationBinding = value;
                OnPropertyChanged("SpecializationBinding");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
            }
            else if (btn.Content.Equals("Save"))
            {
                PhysicianController physicianController = new PhysicianController();
                List<Physician> physicians = physicianController.GetAll();

                RoomController roomController = new RoomController();
                List<Room> rooms = RoomsWindow.roomController.GetAll();

                AppointmentFileHandler handler = new AppointmentFileHandler();
                AppointmentRepository appointmentRepository = new AppointmentRepository(handler);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);
                AppointmentController appointmentController = new AppointmentController(appointmentService);

                if (appointmentController.Add(new Appointment(physicians[0], Patient.SelectedItem as Patient, rooms[2], DateTime.Now, AppointmentTypeBinding)))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Appointment with that reg num already exists!", "Error");
                }
            }
        }


        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(IdBinding) && Patient.SelectedItem != null)
            {
                e.CanExecute = true;
            }

        }

        private void Button_Click_Patient_Account(object sender, RoutedEventArgs e)
        {
            CreatePatient createPatient = new CreatePatient();
            createPatient.Show();
        }

        private void Button_Click_Guest_Account(object sender, RoutedEventArgs e)
        {
            CreateGuestAccount createGuestAccount = new CreateGuestAccount();
            createGuestAccount.Show();
        }

    }
}