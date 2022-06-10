using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class PatientsWindow : Window
    {
        public static PatientsWindow patientsWindowInstance;
        public PatientController patientController;
        public static Patient SelectedPatient { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }

        public PatientsWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            PatientFileHandler fileHandler = new PatientFileHandler();
            PatientRepository repository = new PatientRepository(fileHandler);
            PatientService service = new PatientService(repository);
            patientController = new PatientController(service);

            Patients = new ObservableCollection<Patient>(patientController.GetAll());
        }

        public static PatientsWindow GetPatientsWindow()
        {
            if (patientsWindowInstance == null)
            {
                patientsWindowInstance = new PatientsWindow();

            }

            return patientsWindowInstance;
        }

        public void refreshContentOfGrid()
        {
            dgPatients.ItemsSource = null;
            dgPatients.ItemsSource = patientController.GetAll();

        }

        public Patient getSelectedPatient()
        {
            return (Patient)dgPatients.SelectedItem;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Patient patient = getSelectedPatient();
            if (!btn.Content.Equals("Create") && patient == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }


            if (btn.Content.Equals("Create"))
            {
                CreatePatient createPatient = new CreatePatient();
                createPatient.ShowDialog();
            }
            else if (btn.Content.Equals("Edit"))
            {
                PatientsEdit patientsEdit = new PatientsEdit();
                patientsEdit.ShowDialog();

            }
            else if (btn.Content.Equals("Delete"))
            {
                PatientsDelete patientsDelete = new PatientsDelete();
                patientsDelete.Show();
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            patientsWindowInstance = null;
        }

    }
}