﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Controller;

namespace WpfApp1.View.Secretary
{

    public partial class ChangeSecretaryProfile : Window
    {
        public static string emailBinding;
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

        public static string phoneNumberBinding;
        public string PhoneNumberBinding
        {
            get
            {
                return phoneNumberBinding;
            }
            set
            {
                phoneNumberBinding = value;
                OnPropertyChanged("PhoneNumberBinding");
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
        public ChangeSecretaryProfile()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            EmailBinding = Login.userAccount.Email;
            Name.Text = Login.userAccount.Name;
            Surname.Text = Login.userAccount.Surname;
            PhoneNumberBinding = Login.userAccount.PhoneNumber;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            UserAccountController userAccountController = new UserAccountController();
            userAccountController.EditSecretaryProfile(new Model.Secretary(Email.Text, Name.Text, Surname.Text, PhoneNumber.Text, Login.userAccount.UniquePersonalNumber));
            Login.userAccount = userAccountController.GetByUniquePersonalNumber(Login.userAccount.UniquePersonalNumber);
            ChangeSecretaryProfile secretaryProfile = new ChangeSecretaryProfile();
            secretaryProfile.ShowDialog();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_ChangePassword(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        private void EnableOrDisableSaveBtn()
        {
            if (EnableNextBtn())
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }
        }

        private bool EnableNextBtn()
        {
            return !string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Name.Text) 
            && !string.IsNullOrEmpty(Surname.Text) && !string.IsNullOrEmpty(PhoneNumber.Text) && !Validation.EmailValidationRule.ValidationHasError && !Validation.PhoneNumberValidationRule.ValidationHasError;
        }
    }
}
