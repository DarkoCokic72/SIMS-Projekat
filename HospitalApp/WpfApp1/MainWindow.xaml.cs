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



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            App.RelocationThread.Start();
            App.RenovationThread.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            App.RelocationThread.Abort();
            App.RenovationThread.Abort();
            App.AppointmentEdited.Abort();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("LOGIN"))
            {
                Login login = new Login();
                //this.Close();
                login.Show();

            }    

        }


    }
}
