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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Controller;

namespace WpfApp1.View.Secretary
{
    public partial class ChangePassword : Window
    {

        public ChangePassword()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            SaveBtn.IsEnabled = false;
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (OldPassword.Password != Login.userAccount.Password)
            {
                ErrorLabel.Content = "Wrong old password!";
                return;
            }
            else if (NewPassword.Password != RepeatPassword.Password)
            {
                ErrorLabel.Content = "Passwords do not match!";
                return;
            }
            UserAccountController userAccountController = new UserAccountController();
            userAccountController.ChangeSecretaryPassword(new Model.Secretary(NewPassword.Password, Login.userAccount.UniquePersonalNumber));
            Login.userAccount = userAccountController.GetByUniquePersonalNumber(Login.userAccount.UniquePersonalNumber);
            ChangeSecretaryProfile changeSecretaryProfile = new ChangeSecretaryProfile();
            changeSecretaryProfile.ShowDialog();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChangeSecretaryProfile secretaryProfile = new ChangeSecretaryProfile();
            secretaryProfile.ShowDialog();
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
            return !string.IsNullOrEmpty(OldPassword.Password) && !string.IsNullOrEmpty(NewPassword.Password)
            && !string.IsNullOrEmpty(RepeatPassword.Password);
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }
    }
}
