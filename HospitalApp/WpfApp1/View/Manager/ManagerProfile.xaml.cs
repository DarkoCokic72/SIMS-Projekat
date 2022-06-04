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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.View.Manager
{
    /// <summary>
    /// Interaction logic for ManagerProfile.xaml
    /// </summary>
    public partial class ManagerProfile : UserControl
    {
        public ManagerProfile()
        {
            InitializeComponent();
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            NameAndSurname.Content = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Email.Text = Login.userAccount.Email;
            PhoneNumber.Text = Login.userAccount.PhoneNumber;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Home_Page(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_Click_Rooms(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_EditProfile(object sender, RoutedEventArgs e)
        {
            this.Content = new EditManagerProfile();
        }

        private void MenuItem_Click_ChangePassword(object sender, RoutedEventArgs e)
        {
            this.Content = new ChangePassword();
        }
    }
}
