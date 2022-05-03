using System;
using System.Collections.Generic;
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
using Model;
using WpfApp1.Model;
using WpfApp1.View;


namespace WpfApp1.View.Physiciann.ExaminationAppointments
{
    /// <summary>
    /// Interaction logic for EditAppointmentWindow.xaml
    /// </summary>
    public partial class EditAppointmentWindow : Window
    {
        public static Boolean appointmentEdited = false;
        private ExaminationAppointment examinationAppointment;
        public EditAppointmentWindow()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            examinationAppointment = ExaminationAppointments.ExaminationAppointmentWindow.instace.GetSelectedAppointment();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string idBinding;

        public string IdBinding
        {
            get
            {
                return idBinding;
            }
            set
            {
                idBinding = value;
                OnPropertyChanged("IdBinding");
            }
        }

        private Patient patientBinding;

        public Patient PatientBinding
        {
            get
            {
                return patientBinding;
            }

            set
            {
                patientBinding = value;
                OnPropertyChanged("PatientBinding");
            }
        }

        private DateTime dateBinding;

        public DateTime DateBinding
        {
            get
            {
                return dateBinding;
            }
            set
            {
                dateBinding = value;
                OnPropertyChanged("DateBinding");
            }
        }

        private Room roomBinding;

        public Room RoomBinding
        {
            get
            {
                return roomBinding;
            }
            set
            {
                roomBinding = value;
                OnPropertyChanged("RoomBinding");
            }
        }

        private Physician phisicianBinding;

        public Physician PhisicianBinding
        {
            get
            {
                return phisicianBinding;
            }
            set
            {
                phisicianBinding = value;
                OnPropertyChanged("PhysicianBinding");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
            } else if (btn.Content.Equals("Edit"))
            {
                ExaminationAppointmentWindow.appointmentControler.Update(new ExaminationAppointment(PhisicianBinding, PatientBinding, roomBinding, DateBinding, IdBinding));

                if(appointmentEdited == true)
                {
                    ExaminationAppointmentWindow.instace.RefreshContentGrid();
                    Close();
                } else
                {
                    MessageBox.Show("ID cannot be edited", "Error");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

           
        }
    }
}
