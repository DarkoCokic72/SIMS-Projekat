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
        public static Boolean editedMedicalRecord = false;

        private MedicalRecord medicalRecord;

        private string regNumBinding;
        public string RegNumBinding
        {
            get
            {
                return regNumBinding;
            }
            set
            {
                regNumBinding = value;
                OnPropertyChanged("RegNumBinding");
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

        public MedicalRecordEdit()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            medicalRecord = MedicalRecordWindow.medicalRecordWindowInstance.getSelectedMedicalRecord();

            RegNumBinding = medicalRecord.RegNum;
            PatientBinding = medicalRecord.Patient;
            AllergensBinding = medicalRecord.Allergens;

            // Validation.UPNValidation.ValidationError = false;
            PatientFileHandler patientFileHandler = new PatientFileHandler();
            PatientRepository patientRepository = new PatientRepository(patientFileHandler);
            PatientService patientService = new PatientService(patientRepository);
            PatientController patientController = new PatientController(patientService);
            List<Patient> patients = patientController.GetAll();
            List<string> patientsUPN = new List<string>();

            foreach (Patient r in patients)
            {
                patientsUPN.Add(r.uniquePersonalNumber);
            }

            Patient.ItemsSource = patientsUPN;

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

                MedicalRecordWindow.medicalRecordController.Update(new MedicalRecord(RegNumBinding, PatientBinding, AllergensBinding));

                if (editedMedicalRecord == true)
                {
                    MedicalRecordWindow.medicalRecordWindowInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Medical record with that register number already exists!", "Error");
                }


            }

        }

         
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
            */

        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RegNumBinding))
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
