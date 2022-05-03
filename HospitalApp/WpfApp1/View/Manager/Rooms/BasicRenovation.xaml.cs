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
using Model;
using Repo;
using Service;
using WpfApp1.Controller;
using WpfApp1.FileHandler;

namespace WpfApp1.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for BasicRenovation.xaml
    /// </summary>
    public partial class BasicRenovation : Window, INotifyPropertyChanged
    {
        private RoomController roomController = new RoomController();
        private string roomId;
        private string description;
        public static List<System.DateTime> busyDates;
        public static DateTime startDate;

        private int durationBinding;
        public int DurationBinding
        {
            get
            {
                return durationBinding;
            }
            set
            {
                durationBinding = value;
                OnPropertyChanged("DurationBinding");
            }
        }


        public BasicRenovation(string _roomId, string _description)
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            roomId = _roomId;
            description = _description;

            busyDates = roomController.getBusyDates(roomId);

            foreach (DateTime d in busyDates)
            {
                Calendar.BlackoutDates.Add(new CalendarDateRange(d, d));
            }

            ScheduleBtn.IsEnabled = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
            Validation.MaxDurationValidationRule.ValidationHasError = false;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Duration.Text) && !string.IsNullOrEmpty(Calendar.SelectedDate.ToString()) && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MaxDurationValidationRule.ValidationHasError)
            {
                ScheduleBtn.IsEnabled = true;
            }
            else
            {
                ScheduleBtn.IsEnabled = false;
            }

        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            BasicRenovation1 basicRenovation1 = new BasicRenovation1(roomId, description);
            basicRenovation1.Show();
            Close();
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            
            roomController.SchedulingRenovation(new Model.Renovation(roomController.GetById(roomId), description, startDate, int.Parse(Duration.Text)));
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }


        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            startDate = (DateTime)Calendar.SelectedDate;
            if (!string.IsNullOrEmpty(Duration.Text) && !string.IsNullOrEmpty(Calendar.SelectedDate.ToString()) && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MaxDurationValidationRule.ValidationHasError)
            {
                ScheduleBtn.IsEnabled = true;
            }
            else
            {
               ScheduleBtn.IsEnabled = false;
            }
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_HomePage(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }
    }

}
