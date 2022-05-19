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

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsEditReason.xaml
    /// </summary>
    public partial class DrugsEditReason : UserControl
    {
        public DrugsEditReason()
        {
            InitializeComponent();
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            Reason.Text = DrugsWindow.SelectedDrug.Reason;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsWindow();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsEdit();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }
    }
}
