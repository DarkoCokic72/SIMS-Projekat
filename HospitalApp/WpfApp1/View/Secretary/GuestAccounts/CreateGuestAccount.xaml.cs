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

    public partial class CreateGuestAccount : Window
    {
        public CreateGuestAccount()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Validation.UPNValidation.ValidationError = false;
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

       /* private string passwordBinding;
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

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
                GuestAccountsWindow guestAccountsWindow = GuestAccountsWindow.GetGuestAccountsWindow();
                guestAccountsWindow.ShowDialog();
            }
            else if (btn.Content.Equals("Save"))
            {

                if (GuestAccountsWindow.GetGuestAccountsWindow().guestAccountsController.Add(new GuestAccount(EmailBinding, NameBinding, SurnameBinding, UPNBinding)))
                {
                    GuestAccountsWindow.guestAccountsWindowInstance.refreshContentOfGrid();
                    Close();

                    GuestAccountsWindow guestAccountsWindow = GuestAccountsWindow.GetGuestAccountsWindow();
                    guestAccountsWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("GuestAccount with that ID already exists!", "Error");
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
            if (!string.IsNullOrEmpty(UPNBinding) && !string.IsNullOrEmpty(NameBinding) && !string.IsNullOrEmpty(SurnameBinding) && !string.IsNullOrEmpty(EmailBinding) &&
                !Validation.UPNValidation.ValidationError)
            {
                e.CanExecute = true;
            }

        }
    }
}
