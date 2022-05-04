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

/*

namespace WpfApp1
{

    public partial class AppointmentsWindow : Window
    {
        public static AppointmentsWindow appointmentsWindowInstance;
        public static PatientExaminationAppointmentController patientExaminationAppointmentController;
        public ObservableCollection<PatientExaminationAppointment> PatientExaminationAppointments { get; set; }

        public AppointmentsWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            PatientExaminationAppointmentFileHandler fileHandler = new PatientExaminationAppointmentFileHandler();
            PatientExaminationAppointmentRepository repository = new PatientExaminationAppointmentRepository(fileHandler);
            PatientExaminationAppointmentService service = new PatientExaminationAppointmentService(repository);
            patientExaminationAppointmentController = new PatientExaminationAppointmentController(service);

            PatientExaminationAppointments = new ObservableCollection<PatientExaminationAppointment>(patientExaminationAppointmentController.GetAll());
        }

        public static AppointmentsWindow GetAppointmentsWindow()
        {
            if (appointmentsWindowInstance == null)
            {
                appointmentsWindowInstance = new MedicalRecordWindow();

            }

            return appointmentsWindowInstance;
        }

        public void refreshContentOfGrid()
        {
            DataGridAppointments.ItemsSource = null;
            DataGridAppointments.ItemsSource = patientExaminationAppointmentController.GetAll();

        }

        public MedicalRecord getSelectedMedicalRecord()
        {
            return (MedicalRecord)dgMedicalRecords.SelectedItem; ;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MedicalRecord medicalRecord = getSelectedMedicalRecord();
            if (!btn.Content.Equals("Create") && medicalRecord == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }


            if (btn.Content.Equals("Create"))
            {
                CreateMedicalRecord createMedicalRecord = new CreateMedicalRecord();
                createMedicalRecord.Show();
            }
            else if (btn.Content.Equals("Edit"))
            {

                MedicalRecordEdit medicalRecordEdit = new MedicalRecordEdit();
                medicalRecordEdit.Show();

            }
            else if (btn.Content.Equals("Delete"))
            {

                MedicalRecordDelete medicalRecordDelete = new MedicalRecordDelete();
                medicalRecordDelete.Show();
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            medicalRecordWindowInstance = null;
        }

        public static implicit operator AppointmentsWindow(MedicalRecordWindow v)
        {
            throw new NotImplementedException();
        }
    }
}
*/