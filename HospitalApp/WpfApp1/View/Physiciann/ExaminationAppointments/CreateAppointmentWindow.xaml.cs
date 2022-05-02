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
using Repo;
using Service;
using FileHandler;
using Controller;
using WpfApp1.Model;

namespace WpfApp1.View.Physiciann.ExaminationAppointments
{
    /// <summary>
    /// Interaction logic for CreateAppointmentWindow.xaml
    /// </summary>
    public partial class CreateAppointmentWindow : Window
    {
        public static Boolean appointmentAdded = false;
        public CreateAppointmentWindow()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if(PropertyChanged == null)
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
            } else if (btn.Content.Equals("Add"))
            {
                ExaminationAppointmentWindow.appointmentControler.Add(new ExaminationAppointment(PhisicianBinding, PatientBinding, RoomBinding, DateBinding, IdBinding));

                if(appointmentAdded == true)
                {
                    ExaminationAppointmentWindow.instace.RefreshContentGrid();
                    Close();
                } else
                {
                    MessageBox.Show("There is already an appointment with this id!", "Error");
                }
            }
        }

        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(IdBinding))
            {
                e.CanExecute = true;
            } else
            {
                e.CanExecute = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
