using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using Model;
using Service;
using WpfApp1.View;
using WpfApp1.View.Manager;
using WpfApp1.View.Secretary;
using WpfApp1.View.PatientAppointments;
using Microsoft.SqlServer.Dac.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static EquipmentController equipmentController = new EquipmentController();
        public static Thread thread = new Thread(() =>
        {
            while (true)
            {
                equipmentController.Relocate();   
            }
        });

        public MainWindow()
        {

            //Login login = new Login();
            //login.ShowDialog();

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;




            thread.Start();
             
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            thread.Abort();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Manager"))
            {

                ManagerHomePage managerHomePage = new ManagerHomePage();
                managerHomePage.Show();
             
            } else if(btn.Content.Equals("Secretary"))
            {
                SecretaryHomePage secretaryHomePage = new SecretaryHomePage();
                secretaryHomePage.Show();

            }
            else if (btn.Content.Equals("P.Appointments"))
            {
                Appointments appointments = Appointments.GetAppointments();
                appointments.Show();
            }

        }


    }
}
