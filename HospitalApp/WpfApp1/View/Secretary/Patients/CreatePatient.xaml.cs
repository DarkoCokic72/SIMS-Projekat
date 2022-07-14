using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FileHandler;
using Model;
using Repo;
using WpfApp1.Controller;
using WpfApp1.FileHandler;
using WpfApp1.Model;
using WpfApp1.Repo;
using WpfApp1.Service;
using WpfApp1.Validation;

namespace WpfApp1
{

    public partial class CreatePatient : Window
    {
        public CreatePatient()
        {
            InitializeComponent();
            DataContext = this;
            ComboBox.ItemsSource = Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            UPNValidation.ValidationError = false;
            DateOfBirthBinding = DateTime.Now;
        }


        private string uPNBinding;
        public string UPNBinding
        {
            get
            {
                return uPNBinding;
            }
            set
            {
                uPNBinding = value;
                OnPropertyChanged("UPNBinding");
            }
        }

        private string nameBinding;
        public string NameBinding
        {
            get
            {
                return nameBinding;
            }
            set
            {
                nameBinding = value;
                OnPropertyChanged("NameBinding");
            }
        }

        private string surnameBinding;
        public string SurnameBinding
        {
            get
            {
                return surnameBinding;
            }
            set
            {
                surnameBinding = value;
                OnPropertyChanged("SurnameBinding");
            }
        }

        private string emailBinding;
        public string EmailBinding
        {
            get
            {
                return emailBinding;
            }
            set
            {
                emailBinding = value;
                OnPropertyChanged("EmailBinding");
            }
        }

        private BloodGroup bloodGroupBinding;
        public BloodGroup BloodGroupBinding
        {
            get
            {
                return bloodGroupBinding;
            }
            set
            {
                bloodGroupBinding = value;
                OnPropertyChanged("BloodGroupBinding");
            }
        }

        private string phoneNumBinding;
        public string PhoneNumBinding
        {
            get
            {
                return phoneNumBinding;
            }
            set
            {
                phoneNumBinding = value;
                OnPropertyChanged("PhoneNumBinding");
            }
        }

        private DateTime dateOfBirthBinding;
        public DateTime DateOfBirthBinding
        {
            get
            {
                return dateOfBirthBinding;
            }
            set
            {
                dateOfBirthBinding = value;
                OnPropertyChanged("DateOfBirthBinding");
            }
        }
/*
        private string passwordBinding;
        public string PasswordBinding
        {
            get
            {
                return passwordBinding;
            }
            set
            {
                passwordBinding = value;
                OnPropertyChanged("PasswordBinding");
            }
        }

*/
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
            PatientsWindow patientsWindow = PatientsWindow.GetPatientsWindow();
            patientsWindow.ShowDialog();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            PatientFileHandler patientFileHandler = new PatientFileHandler();
            PatientRepository patientRepository = new PatientRepository(patientFileHandler);

            ManagerFileHandler managerFileHandler = new ManagerFileHandler();
            ManagerRepository managerRepository = new ManagerRepository(managerFileHandler);

            SecretaryFileHandler secretaryFileHandler = new SecretaryFileHandler();
            SecretaryRepository secretaryRepository = new SecretaryRepository(secretaryFileHandler);

            PhysicianFileHandler physicianFileHandler = new PhysicianFileHandler();
            PhysicianRepository physicianRepository = new PhysicianRepository();

            GuestAccountFileHandler guestAccountFileHandler = new GuestAccountFileHandler();
            GuestAccountRepository guestAccountRepository = new GuestAccountRepository(guestAccountFileHandler);

            if (patientRepository.EmailExists(EmailBinding))
            {
                MessageBox.Show("Email already exists!", "Error");
            }
            else if (managerRepository.EmailExists(EmailBinding))
            {
                MessageBox.Show("Email already exists!", "Error");
            }
            else if (secretaryRepository.EmailExists(EmailBinding))
            {
                MessageBox.Show("Email already exists!", "Error");
            }
            else if (physicianRepository.EmailExists(EmailBinding))
            {
                MessageBox.Show("Email already exists!", "Error");
            }
            else if (guestAccountRepository.EmailExists(EmailBinding))
            {
                MessageBox.Show("Email already exists!", "Error");
            }

            else if (patientRepository.UPNExists(UPNBinding))
            {
                MessageBox.Show("UPN already exists!", "Error");
            }
            else if (managerRepository.UPNExists(UPNBinding))
            {
                MessageBox.Show("UPN already exists!", "Error");
            }
            else if (secretaryRepository.UPNExists(UPNBinding))
            {
                MessageBox.Show("UPN already exists!", "Error");
            }
            else if (physicianRepository.UPNExists(UPNBinding))
            {
                MessageBox.Show("UPN already exists!", "Error");
            }
            else if (guestAccountRepository.UPNExists(UPNBinding))
            {
                MessageBox.Show("UPN already exists!", "Error");
            }

            else if (PatientsWindow.GetPatientsWindow().patientController.Add(new Patient(EmailBinding, NameBinding, SurnameBinding, PhoneNumBinding, UPNBinding, DateOfBirthBinding, BloodGroupBinding)))
            {
                PatientsWindow.patientsWindowInstance.refreshContentOfGrid();
                Close();
                PatientsWindow patientsWindow = PatientsWindow.GetPatientsWindow();
                patientsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mistake!", "Error");
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
            if (!string.IsNullOrEmpty(UPNBinding) && !string.IsNullOrEmpty(NameBinding) && !string.IsNullOrEmpty(SurnameBinding) && !string.IsNullOrEmpty(EmailBinding) && !string.IsNullOrEmpty(PhoneNumBinding) && !UPNValidation.ValidationError)
            {
                e.CanExecute = true;
            }

        }
    }
}
