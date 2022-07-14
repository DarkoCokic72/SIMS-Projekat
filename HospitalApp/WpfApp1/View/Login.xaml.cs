using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Controller;
using WpfApp1.FileHandler;
using WpfApp1.Repo;
using WpfApp1.Service;
using WpfApp1.View.Manager;
using WpfApp1.View.Patientt;
using WpfApp1.View.Physiciann.ExaminationAppointments;
using WpfApp1.View.Secretary;

namespace WpfApp1.View
{
    public partial class Login : UserControl
    {
        public static UserAccount userAccount;
        public Login()
        {
            ManagerHomePage.managerHomePageInstance = null;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel.Content = "Please enter your email!";
                return;
            }

            if (string.IsNullOrEmpty(LoginPassword.Password))
            {
                ErrorLabel.Content = "Please enter your password!";
                return;
            }
            if (!Regex.IsMatch(Email.Text, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"))
            {
                ErrorLabel.Content = "Wrong email format!";
                return;
            }
            

            UserAccountFileHandler userAccountFileHandler = new UserAccountFileHandler();
            UserAccountRepository userAccountRepository = new UserAccountRepository(userAccountFileHandler);
            UserAccountService userAccountService = new UserAccountService(userAccountRepository);
            UserAccountController userAccountController = new UserAccountController(userAccountService);
            userAccount = userAccountController.GetByEmailPassword(Email.Text, LoginPassword.Password);
            
            if (userAccount == null)
            {
                ErrorLabel.Content = "Wrong email or/and password!";
                return;
            }
            if (userAccount != null) 
            {

                if (userAccount.GetType() == typeof(Model.Secretary)) 
                {
                    SecretaryLogin();
                }
                if (userAccount.GetType() == typeof(Model.Manager))
                {
                    ManagerLogin();
                }
                if (userAccount.GetType() == typeof(Model.Patient))
                {

                    PatientLogin();

                }
                if (userAccount.GetType() == typeof(Model.Physician))
                {
                    PhysicianLogin();
                }
                App.CheckNotification = true;
                if (App.AppointmentEdited.ThreadState != System.Threading.ThreadState.Running) 
                {
                    try
                    {
                        App.AppointmentEdited.Start();
                    }
                    catch (Exception ex) 
                    {
                    }
                }
                

                
            }
            
        }

        private void ManagerLogin()
        {
            this.Content = ManagerHomePage.GetManagerHomePage();
            return;
        }

        private void SecretaryLogin()
        {
            SecretaryHomePage secretaryHomePage = new SecretaryHomePage();
            
            secretaryHomePage.ShowDialog();
            return;
        }

        private void PatientLogin()
        {
            PatientHomePage patientHomePage = new PatientHomePage();
            
            patientHomePage.ShowDialog();
            return;
        }

        private void PhysicianLogin()
        {
            ExaminationAppointmentWindow examinationAppointmentWindow = new ExaminationAppointmentWindow();
            
            examinationAppointmentWindow.ShowDialog();
            return;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void LoginWindow_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
