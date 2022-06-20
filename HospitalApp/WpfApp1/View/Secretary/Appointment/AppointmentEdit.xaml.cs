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
using Controller;
using FileHandler;
using Model;
using Repo;
using Service;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace WpfApp1
{
    public partial class AppointmentEdit : Window, INotifyPropertyChanged
    {
        private Appointment appointment;

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

        public AppointmentEdit()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            appointment = AppointmentWindow.appointmentWindowInstance.getSelectedAppointment();

            Type.ItemsSource = Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>();
            Patient.ItemsSource = FillComboBoxWithPatients();
            Room.ItemsSource = FillComboBoxWithRooms();
            Physician.ItemsSource = FillComboBoxWithPhysicians();

            Room.SelectedItem = appointment.Room;
            Patient.SelectedItem = appointment.Patient;
            Physician.SelectedItem = appointment.Physician;
            DateOfAppointment.Value = appointment.DateOfAppointment;
            Type.SelectedItem = appointment.Type;
        }

        private List<Room> FillComboBoxWithRooms()
        {
            RoomController roomController = new RoomController();
            List<Room> rooms = roomController.GetAll();
            List<Room> roomsId = new List<Room>();
            foreach (Room room in rooms)
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
            List<Physician> physicians = physicianController.GetAll();
            List<Physician> physiciansId = new List<Physician>();
            foreach (Physician physician in physicians)
            {
                physiciansId.Add(physician);
            }
            return physiciansId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            /* if (UPNBinding == patient.uniquePersonalNumber && NameBinding == patient.name && SurnameBinding == patient.surname && BloodGroupBinding == patient.bloodGroup && EmailBinding == patient.email && PhoneNumBinding == patient.phoneNumber && DateOfBirthBinding == patient.dateOfBirth && PasswordBinding == patient.password)
             {
                 SaveBtn.IsEnabled = false;
             }
             else if (string.IsNullOrEmpty(UPNBinding) || string.IsNullOrEmpty(NameBinding))
             {
                 SaveBtn.IsEnabled = false;
             }
             else if (Validation.StringToIntegerValidationRule.ValidationHasError || Validation.MinMaxValidationRule.ValidationHasError || Validation.IdValidationRule.ValidationHasError)
             {
                 SaveBtn.IsEnabled = false;
             }
             else
             {
                 SaveBtn.IsEnabled = true;
             }*/
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
                //AppointmentWindow appointmentWindow = AppointmentWindow.GetAppointmentWindow();
                //appointmentWindow.ShowDialog();
            }
            else if (btn.Content.Equals("Save"))
            {
                if (AppointmentWindow.GetAppointmentWindow().appointmentController.Update(new Appointment(Physician.SelectedItem as Physician, Patient.SelectedItem as Patient, Room.SelectedItem as Room, DateOfAppointment.Value.Value, AppointmentTypeBinding)))
                {
                    AppointmentWindow.appointmentWindowInstance.refreshContentOfGrid();
                    Close();

                    //AppointmentWindow appointmentWindow = AppointmentWindow.GetAppointmentWindow();
                    //appointmentWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mistake! ERROR!", "Error");
                }
            }

        }


        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Physician.SelectedItem != null && Patient.SelectedItem != null && Room.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}
