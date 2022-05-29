using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class BasicRenovation : UserControl, INotifyPropertyChanged
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
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            roomId = _roomId;
            description = _description;

            busyDates = roomController.GetBusyDates(roomId);

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
            this.Content = new BasicRenovation1(roomId, description);
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            
            roomController.SchedulingRenovation(new Model.Renovation(roomController.GetById(roomId), description, startDate, int.Parse(Duration.Text)));
            this.Content = new ManagerHomePage();
            new SuccessfulActionWindow("Renovation was scheduled!");      
        }


        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            startDate = (DateTime)Calendar.SelectedDate;
            BindingExpression binding = Duration.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
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
            this.Content = new Login();
        }


        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
