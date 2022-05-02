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
using Model;
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class PatientsEdit : Window, INotifyPropertyChanged
    {
        public static Boolean editedPatient = false;
        private Patient patient;

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

        private String passwordBinding;
        public String PasswordBinding
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



        public PatientsEdit()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            ComboBox.ItemsSource = Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>();
            patient = PatientsWindow.patientsWindowInstance.getSelectedPatient();

            UPNBinding = patient.uniquePersonalNumber;
            NameBinding = patient.name;
            SurnameBinding = patient.surname;
            BloodGroupBinding = patient.bloodGroup;
            EmailBinding = patient.email;
            PhoneNumBinding = patient.phoneNumber;
            DateOfBirthBinding = patient.dateOfBirth;
            PasswordBinding = patient.password;

            Validation.UPNValidation.ValidationError = false;

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

                PatientsWindow.patientController.Update(new Patient(EmailBinding, PasswordBinding, NameBinding, SurnameBinding, PhoneNumBinding, UPNBinding, DateOfBirthBinding, BloodGroupBinding));

                if (editedPatient == true)
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((BloodGroup)ComboBox.SelectedItem != patient.bloodGroup && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MinMaxValidationRule.ValidationHasError && !Validation.IdValidationRule.ValidationHasError)
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }
        }
    }
}
