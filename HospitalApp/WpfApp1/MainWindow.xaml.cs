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
using WpfApp1.View.Manager;

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
             
            } else if(btn.Content.Equals("Patients"))
            {
                PatientsWindow patientsWindow = PatientsWindow.GetPatientsWindow();
                patientsWindow.Show();

            }

        }


    }
}
