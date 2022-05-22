using Model;
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

        private String emailBinding;
        public String EmailBinding
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public Login()
        {
            InitializeComponent();
            ManagerHomePage.managerHomePageInstance = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            UserAccountFileHandler userAccountFileHandler = new UserAccountFileHandler();
            UserAccountRepository userAccountRepository = new UserAccountRepository(userAccountFileHandler);
            UserAccountService userAccountService = new UserAccountService(userAccountRepository);
            UserAccountController userAccountController = new UserAccountController(userAccountService);
            Console.WriteLine(EmailBinding);
            userAccount = userAccountController.GetByEmailPassword(Email.Text, LoginPassword.Text);
            

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
    }
}
