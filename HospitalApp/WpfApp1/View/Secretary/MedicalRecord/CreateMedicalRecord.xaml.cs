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

            MedicalRecordFileHandler medicalRecordFileHandler = new MedicalRecordFileHandler();
            MedicalRecordRepository medicalRecordRepository = new MedicalRecordRepository(medicalRecordFileHandler);
            MedicalRecordService medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            MedicalRecordController medicalRecordController = new MedicalRecordController(medicalRecordService);
            List<MedicalRecord> medicalRecords = medicalRecordController.GetAll();

            foreach (Patient patient in patients)
               // foreach (MedicalRecord medicalRecord in medicalRecords)
                {
                   // if (patient != medicalRecord.Patient)
                    patientsUPN.Add(patient);
                }
            Patient.ItemsSource = patientsUPN;
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
                MedicalRecordWindow medicalRecordWindow = MedicalRecordWindow.GetMedicalRecordWindow();
                medicalRecordWindow.ShowDialog();
            }
            else if (btn.Content.Equals("Save"))
            {   
                if (MedicalRecordWindow.GetMedicalRecordWindow().medicalRecordController.Add(new MedicalRecord(Patient.SelectedItem as Patient, AllergensBinding)))
                {
                    MedicalRecordWindow.medicalRecordWindowInstance.refreshContentOfGrid();
                    Close();
                    MedicalRecordWindow medicalRecordWindow = MedicalRecordWindow.GetMedicalRecordWindow();
                    medicalRecordWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Medical record with that reg num already exists!", "Error");
                }
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Patient.SelectedItem != null)
            {
                e.CanExecute = true;
            }

        }

       
    }
}