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
using Controller;
using System.Collections.ObjectModel;
using WpfApp1.Model;
using Model;
using FileHandler;
using Repo;
using Service;
using WpfApp1.Controller;
using WpfApp1.View.Physiciann.ExaminationAppointments;

namespace WpfApp1.View.Physiciann.ExaminationAppointments
{
    /// <summary>
    /// Interaction logic for ExaminationAppointmentWindow.xaml
    /// </summary>
    public partial class ExaminationAppointmentWindow : Window
    {
        public static ExaminationAppointmentWindow instace;
        public static Controller.ExaminationAppointmentControler appointmentControler;
        public static ExaminationAppointment SelectedAppointment { get; set; }
        public ObservableCollection<ExaminationAppointment> Appointments { get; set; }
        

        public ExaminationAppointmentWindow()
        {
            
            InitializeComponent();
            DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            appointmentControler = new Controller.ExaminationAppointmentControler();
            Appointments = new ObservableCollection<ExaminationAppointment>(appointmentControler.GetAll());
        }

        public static ExaminationAppointmentWindow getInstance()
        {
            if(instace == null)
            {
                instace = new ExaminationAppointmentWindow();
            }

            return instace;
        }

        public void RefreshContentGrid() {
            dgAppointments.ItemsSource = null;
            dgAppointments.ItemsSource = appointmentControler.GetAll();
        }

        public ExaminationAppointment GetSelectedAppointment()
        {
            return (ExaminationAppointment)dgAppointments.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            ExaminationAppointment appointment = GetSelectedAppointment();

            if(!btn.Content.Equals("Add") && appointment == null)
            {
                MessageBox.Show("You need to select a row first!", "Error");
                return;
            }

            if (btn.Content.Equals("Add"))
            {
                CreateAppointmentWindow create = new CreateAppointmentWindow();
                create.Show();
            } else if (btn.Content.Equals("Edit")) 
            {
                EditAppointmentWindow edit = new EditAppointmentWindow();
                edit.Show();
            }
            else if (btn.Content.Equals("Delete"))
            {
                DeleteAppointmentWindow delete = new DeleteAppointmentWindow();
                delete.Show();
            }
        }


    }
}
