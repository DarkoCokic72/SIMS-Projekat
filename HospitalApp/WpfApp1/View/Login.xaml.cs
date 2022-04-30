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
using WpfApp1.View.Secretary;

namespace WpfApp1.View
{
    public partial class Login : Window
    {

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

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccountFileHandler userAccountFileHandler = new UserAccountFileHandler();
            UserAccountRepository userAccountRepository = new UserAccountRepository(userAccountFileHandler);
            UserAccountService userAccountService = new UserAccountService(userAccountRepository);
            UserAccountController userAccountController = new UserAccountController(userAccountService);
            UserAccount userAccount = userAccountController.GetByEmailPassword(EmailBinding, PasswordBinding);


            if (userAccount != null) 
            {

                if (userAccount.GetType() == typeof(Patient)) 
                {
                    SecretaryHomePage secretaryHomePage = new SecretaryHomePage();
                    secretaryHomePage.ShowDialog();
                    this.Close();
                    return;
                }

                if (userAccount.GetType() == typeof(Model.Manager))
                {
                    ManagerHomePage managerHomePage = new ManagerHomePage();
                    managerHomePage.ShowDialog();
                    this.Close();
                    return;
                }


                this.Close();
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
    }
}
