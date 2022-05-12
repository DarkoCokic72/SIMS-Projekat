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
        public static Boolean editedAppointment = false;

        private Appointment appointment;

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

            IdBinding = appointment.Id;
            PatientBinding = appointment.Patient;
            PhysicianBinding = appointment.Physician;
            DateOfAppointmentBinding = appointment.DateOfAppointment;
            RoomBinding = appointment.Room;
            AppointmentTypeBinding = appointment.Type;

            Type.ItemsSource = Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>();
            Patient.ItemsSource = FillComboBoxWithPatients();
            Room.ItemsSource = FillComboBoxWithRooms();
            Physician.ItemsSource = FillComboBoxWithPhysicians();


            /*
            //Patients ComboBox
            PatientFileHandler patientFileHandler = new PatientFileHandler();
            PatientRepository patientRepository = new PatientRepository(patientFileHandler);
            PatientService patientService = new PatientService(patientRepository);
            PatientController patientController = new PatientController(patientService);
            List<Patient> patients = patientController.GetAll();
            List<string> patientsComboBox = new List<string>();

            foreach (Patient patient in patients)
            {
                patientsComboBox.Add(patient.name + " " + patient.surname);
            }
            Patient.ItemsSource = patientsComboBox;

            //Physician ComboBox
            PhysicianFileHandler physicianFileHandler = new PhysicianFileHandler();
            PhysicianRepository physicianRepository = new PhysicianRepository(physicianFileHandler);
            PhysicianService physicianService = new PhysicianService(physicianRepository);
            PhysicianController physicianController = new PhysicianController(physicianService);
            List<Physician> physicians = physicianController.GetAll();
            List<string> physiciansComboBox = new List<string>();

            foreach (Physician physician in physicians)
            {
                physiciansComboBox.Add(physician.name + " " + physician.surname);
            }
            Physician.ItemsSource = physiciansComboBox;

            //Room ComboBox
            RoomFileHandler roomFileHandler = new RoomFileHandler();
            RoomRepository roomRepository = new RoomRepository(roomFileHandler);
            RoomService roomService = new RoomService(roomRepository);
            RoomController roomController = new RoomController(roomService);
            List<Room> rooms = roomController.GetAll();
            List<string> roomsComboBox = new List<string>();

            foreach (Room room in rooms)
            {
                roomsComboBox.Add(room.Id + " " + room.Name);
            }
            Room.ItemsSource = roomsComboBox;
            */
        }

        private List<string> FillComboBoxWithRooms()
        {
            List<string> roomsId = new List<String>();
            foreach (Room room in RoomsWindow.roomController.GetAll())
            {
                if (RoomsWindow.SelectedRoom.Id != room.Id)
                {
                    roomsId.Add(room.Id);
                }
            }

            return roomsId;
        }
        private List<string> FillComboBoxWithPatients()
        {
            List<string> patientsId = new List<String>();
            foreach (Patient patient in PatientsWindow.patientController.GetAll())
            {
                if (PatientsWindow.SelectedPatient.uniquePersonalNumber != patient.uniquePersonalNumber)
                {
                    patientsId.Add(patient.uniquePersonalNumber);
                }
            }

            return patientsId;
        }
        private List<string> FillComboBoxWithPhysicians()
        {
            PhysicianController physicianController = new PhysicianController();
            List<Physician> physicians = physicianController.GetAll();
            List<string> physiciansId = new List<string>();
            foreach (Physician physician in physicians)
            {
                //if(RoomsWindow.SelectedRoom.Id != room.Id)
                // {
                physiciansId.Add(physician.licenceID);
                // }
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
            }
            else if (btn.Content.Equals("Save"))
            {

                AppointmentWindow.appointmentController.Update(new Appointment(PhysicianBinding, PatientBinding, RoomBinding, DateOfAppointmentBinding, IdBinding, AppointmentTypeBinding));

                if (editedAppointment == true)
                {
                    AppointmentWindow.appointmentWindowInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Appointment with that register number already exists!", "Error");
                }


            }

        }


        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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
    }
}
