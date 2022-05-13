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
using Controller;
using Model;

namespace WpfApp1.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for MergeRooms2.xaml
    /// </summary>
    public partial class MergeRooms2 : Window
    {
        private RoomController roomController = new RoomController();
        public static List<System.DateTime> busyDates;
        public static DateTime startDate;

        private Room room1;
        private Room room2;
        private string newId;
        private string newName;
        private RoomType newType;
        public MergeRooms2(Room _room1, Room _room2, string _newId, string _newName, RoomType _newType)
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            room1 = _room1;
            room2 = _room2;
            newId = _newId;
            newName = _newName;
            newType = _newType;

            busyDates = roomController.GetBusyDates(room1.Id);
            foreach (DateTime day in roomController.GetBusyDates(room2.Id))
            {
                busyDates.Add(day);
            }

            foreach (DateTime day in busyDates)
            {
                Calendar.BlackoutDates.Add(new CalendarDateRange(day, day));
            }

            ScheduleBtn.IsEnabled = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
            Validation.MaxDurationValidationRule.ValidationHasError = false;
        }

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
            EnableOrDisableScheduleBtn();
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MergeRooms1 mergeRooms1 = new MergeRooms1(room1, room2, newId, newName, newType);
            mergeRooms1.Show();
            Close();
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            Room room3 = new Room(newId, newName, newType, room1.Floor);
            roomController.SchedulingAdvancedRenovation(new AdvancedRenovation(RenovationType.merge, startDate, int.Parse(Duration.Text), room1, room2, room3));
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void EnableOrDisableScheduleBtn()
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

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            startDate = (DateTime)Calendar.SelectedDate;
            EnableOrDisableScheduleBtn();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
