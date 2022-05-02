using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model;
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class CreatePatient : Window
    {

        public static bool addedPatient = false;
        public CreatePatient()
        {
            InitializeComponent();
            DataContext = this;
            ComboBox.ItemsSource = Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

           
            Validation.UPNValidation.ValidationError = false;
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

                PatientsWindow.patientController.Add(new Patient(EmailBinding, PasswordBinding, NameBinding, SurnameBinding, PhoneNumBinding, UPNBinding, DateOfBirthBinding, BloodGroupBinding));
                addedPatient = true;
                if (addedPatient == true)
                {
                    PatientsWindow.patientsWindowInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Patient with that ID already exists!", "Error");
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
            if (!string.IsNullOrEmpty(UPNBinding) && !string.IsNullOrEmpty(NameBinding) && !string.IsNullOrEmpty(SurnameBinding) && !string.IsNullOrEmpty(EmailBinding) && !string.IsNullOrEmpty(PhoneNumBinding) && !string.IsNullOrEmpty(PasswordBinding) &&
                !Validation.UPNValidation.ValidationError)
            {
                e.CanExecute = true;
            }

        }

    }
}
