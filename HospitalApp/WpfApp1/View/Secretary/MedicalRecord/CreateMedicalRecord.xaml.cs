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
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class CreateMedicalRecord : Window
    {

        public static bool addedMedicalRecord = false;
        public CreateMedicalRecord()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

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
            Patient.ItemsSource = patientsUPN;
        }



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

                MedicalRecordWindow.medicalRecordController.Add(new MedicalRecord(RegNumBinding, Patient.SelectedItem as Patient, AllergensBinding));
                addedMedicalRecord = true;
                if (addedMedicalRecord == true)
                {
                    MedicalRecordWindow.medicalRecordWindowInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Medical record with that reg num already exists!", "Error");
                }
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(RegNumBinding))
            {
                e.CanExecute = true;
            }

        }

       
    }
}