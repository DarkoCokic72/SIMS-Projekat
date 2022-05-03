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
            List<string> patientsUPN = new List<string>();

            foreach (Patient r in patients)
            {
                patientsUPN.Add(r.name + " " + r.surname);
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

       
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

                MedicalRecordWindow.medicalRecordController.Add(new MedicalRecord(RegNumBinding, PatientBinding, AllergensBinding));
                addedMedicalRecord = true;
                if (addedMedicalRecord == true)
                {
                    MedicalRecordWindow.medicalRecordWindowInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Error! Choose all!", "Error");
                }
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



        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(RegNumBinding))
            {
                e.CanExecute = true;
            }

        }

        private void Patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Patient.SelectedItem))
            {
                //Save_CanExecute.IsEnabled = true;
            }
        }
    }
}