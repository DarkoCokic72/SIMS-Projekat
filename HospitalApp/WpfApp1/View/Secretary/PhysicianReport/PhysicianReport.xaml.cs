using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class PhysicianReport : Window
    {
        public PhysicianReport()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            StartDateBinding = DateTime.Now;
            EndDateBinding = DateTime.Now;
            Physician.ItemsSource = FillComboBoxWithPhysicians();
        }
        private List<Physician> FillComboBoxWithPhysicians()
        {
            PhysicianController physicianController = new PhysicianController();
            List<Physician> physicians = physicianController.GetAll();
            List<Physician> physiciansId = new List<Physician>();
            foreach (Physician physician in physicians)
            {
                physiciansId.Add(physician);
            }
            return physiciansId;
        }

        private DateTime startDateBinding;
        public DateTime StartDateBinding
        {
            get
            {
                return startDateBinding;
            }
            set
            {
                startDateBinding = value;
                OnPropertyChanged("StartDateBinding");
            }
        }

        private DateTime endDateBinding;
        public DateTime EndDateBinding
        {
            get
            {
                return endDateBinding;
            }
            set
            {
                endDateBinding = value;
                OnPropertyChanged("EndBinding");
            }
        }

        private Physician physicianBinding;
        public Physician PhysicianBinding
        {
            get
            {
                return physicianBinding;
            }
            set
            {
                physicianBinding = value;
                OnPropertyChanged("PhysicianBinding");
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

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

            AppointmentsWindow appointmentsWindow = new AppointmentsWindow(Physician.SelectedItem as Physician, StartDateBinding, EndDateBinding);
            appointmentsWindow.ShowDialog();
            Close();

        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (PhysicianBinding != null)
            {
                e.CanExecute = true;
            }

        }


    }
}
