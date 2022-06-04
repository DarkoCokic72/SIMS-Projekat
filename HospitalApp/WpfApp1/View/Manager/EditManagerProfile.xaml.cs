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
using WpfApp1.Controller;

namespace WpfApp1.View.Manager
{
    /// <summary>
    /// Interaction logic for EditManagerProfile.xaml
    /// </summary>
    public partial class EditManagerProfile : UserControl
    {
        public EditManagerProfile()
        {
            InitializeComponent();
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Email.Text = Login.userAccount.Email;
            Name.Text = Login.userAccount.Name;
            Surname.Text = Login.userAccount.Surname;
            PhoneNumber.Text = Login.userAccount.PhoneNumber;
        }

        private void Button_Click_Home_Page(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            UserAccountController userAccountController = new UserAccountController();
            userAccountController.EditManagerProfile(new Model.Manager(Email.Text, Name.Text, Surname.Text, PhoneNumber.Text, Login.userAccount.UniquePersonalNumber));
            Login.userAccount = userAccountController.GetByUniquePersonalNumber(Login.userAccount.UniquePersonalNumber);
            this.Content = new ManagerProfile();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }
    }
}
