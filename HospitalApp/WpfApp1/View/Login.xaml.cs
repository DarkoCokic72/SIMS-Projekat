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
    public partial class Login : Window
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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccountFileHandler userAccountFileHandler = new UserAccountFileHandler();
            UserAccountRepository userAccountRepository = new UserAccountRepository(userAccountFileHandler);
            UserAccountService userAccountService = new UserAccountService(userAccountRepository);
            UserAccountController userAccountController = new UserAccountController(userAccountService);
            userAccount = userAccountController.GetByEmailPassword(EmailBinding, PasswordBinding);


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
                

                this.Close();
            }
            
        }

        private void ManagerLogin()
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            this.Close();
            managerHomePage.ShowDialog();
            return;
        }

        private void SecretaryLogin()
        {
            SecretaryHomePage secretaryHomePage = new SecretaryHomePage();
            this.Close();
            secretaryHomePage.ShowDialog();
            return;
        }

        private void PatientLogin()
        {
            PatientHomePage patientHomePage = new PatientHomePage();
            this.Close();
            patientHomePage.ShowDialog();
            return;
        }

        private void PhysicianLogin()
        {
            ExaminationAppointmentWindow examinationAppointmentWindow = new ExaminationAppointmentWindow();
            this.Close();
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
    }
}
