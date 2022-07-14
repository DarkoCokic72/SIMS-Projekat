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
using WpfApp1.Model;

namespace WpfApp1
{
    public partial class MedicalRecordEdit : Window, INotifyPropertyChanged
    {
        private MedicalRecord medicalRecord;
        private Patient patient;
        MedicalRecordController medicalRecordController;

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

        private string allergensBinding;
        public string AllergensBinding
        {
            get
            {
                return allergensBinding;
            }
            set
            {
                allergensBinding = value;
                OnPropertyChanged("AllergensBinding");
            }
        }

        public MedicalRecordEdit(Patient patient)
        {

            InitializeComponent();
            this.patient = patient;
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            MedicalRecordFileHandler medicalRecordFileHandler = new MedicalRecordFileHandler();
            MedicalRecordRepository medicalRecordRepository = new MedicalRecordRepository(medicalRecordFileHandler);
            MedicalRecordService medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            medicalRecordController = new MedicalRecordController(medicalRecordService);

            medicalRecord = medicalRecordController.GetByPatient(patient);

            if (medicalRecord == null) 
            {
                MessageBox.Show("There is no medical record");
                return;
            }

            Patient.ItemsSource = ComboBoxPatients();

            Patient.SelectedItem = medicalRecord.Patient;
            AllergensBinding = medicalRecord.Allergens;

        }

        public MedicalRecordEdit(MedicalRecord med)
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            MedicalRecordFileHandler medicalRecordFileHandler = new MedicalRecordFileHandler();
            MedicalRecordRepository medicalRecordRepository = new MedicalRecordRepository(medicalRecordFileHandler);
            MedicalRecordService medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            medicalRecordController = new MedicalRecordController(medicalRecordService);

            medicalRecord = med;

            if (medicalRecord == null)
            {
                MessageBox.Show("There is no medical record");
                return;
            }

            Patient.ItemsSource = ComboBoxPatients();

            Patient.SelectedItem = medicalRecord.Patient;
            AllergensBinding = medicalRecord.Allergens;

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
        /*
        private void Patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // if ((BloodGroup)ComboBox.SelectedItem != patient.bloodGroup && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MinMaxValidationRule.ValidationHasError && !Validation.IdValidationRule.ValidationHasError)
            {
                //SaveBtn.IsEnabled = true;
            }
            /*
              else
            {
                SaveBtn.IsEnabled = false;
            }
            

        }
        */


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
            }
            else if (btn.Content.Equals("Save"))
            {
                MedicalRecord med = new MedicalRecord(Patient.SelectedItem as Patient, AllergensBinding);
                med.RegNum = medicalRecord.RegNum;
                if (medicalRecordController.Update(med))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Medical record with that register number already exists!", "Error");
                }


            }

        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

                e.CanExecute = true;
        }
        
    }
}
