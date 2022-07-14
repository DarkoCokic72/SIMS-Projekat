using System;
using System.Collections.Generic;
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

namespace WpfApp1.View.Manager
{
    /// <summary>
    /// Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        private string email;
        private string name;
        private string surname;
        private string phoneNumber;
        public ConfirmationWindow(string _email, string _name, string _surname, string _phoneNumber)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.Manual;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Top = 0.26 * height;
            Left = 0.275 * width;
            email = _email;
            name = _name;
            surname = _surname;
            phoneNumber = _phoneNumber;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Password))
            {
                Error.Content = "Please enter your password!";
                return;
            }
            if (Password.Password != Login.userAccount.Password)
            {
                Error.Content = "Wrong password!";
                return;
            }

            UserAccountController userAccountController = new UserAccountController();
            userAccountController.EditManagerProfile(new Model.Manager(email, name, surname, phoneNumber, Login.userAccount.UniquePersonalNumber));
            Login.userAccount = userAccountController.GetByUniquePersonalNumber(Login.userAccount.UniquePersonalNumber);
            ManagerHomePage.GetManagerHomePage().Content = new ManagerProfile();
            Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
