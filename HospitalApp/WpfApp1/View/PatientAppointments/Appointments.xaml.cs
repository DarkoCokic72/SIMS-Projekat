﻿using System;
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
using FileHandler;
using Model;
using Repo;
using Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfApp1.Model;

namespace WpfApp1.View.PatientAppointments
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {

        public static PatientExaminationAppointmentController patientAppointmentController;
        public static Appointments AppointmentsInstance;
        public ObservableCollection<PatientExaminationAppointment> Appointment { get; set; }
        public Appointments()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patientAppointmentController = new PatientExaminationAppointmentController();
            Appointment = new ObservableCollection<PatientExaminationAppointment>(patientAppointmentController.GetAll());
        }
        public static Appointments GetAppointments()
        {
            if (AppointmentsInstance == null)
            {
                AppointmentsInstance = new Appointments();

            }

            return AppointmentsInstance;
        }

        public void refreshContentOfGrid()
        {
            DataGridAppointments.ItemsSource = null;
            DataGridAppointments.ItemsSource = patientAppointmentController.GetAll();

        }

        public PatientExaminationAppointment getSelectedAppointments()
        {
            return (PatientExaminationAppointment)DataGridAppointments.SelectedItem;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button New = (Button)sender;
            PatientExaminationAppointment Appointments = getSelectedAppointments();
            if(!New.Content.Equals("New") && Appointments==null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }

            if (New.Content.Equals("New"))
            {

                NewAppointment newAppointments = new NewAppointment();
                newAppointments.Show();
            }
            Button Delete = (Button)sender;
            if (Delete.Content.Equals("Delete"))
            {
                patientAppointmentController.Delete(Appointments.id);
                AppointmentsInstance.refreshContentOfGrid();

            }
            Button Edit = (Button)sender;
            if (Edit.Content.Equals("Edit"))
            {
                EditAppointment editAppointments = new EditAppointment();
                editAppointments.Show();

            }


        }
        protected override void OnClosing(CancelEventArgs e)
        {
            AppointmentsInstance = null;
        }
    }
}
