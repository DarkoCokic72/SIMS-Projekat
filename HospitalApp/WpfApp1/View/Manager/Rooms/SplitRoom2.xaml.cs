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
    /// Interaction logic for SplitRoom2.xaml
    /// </summary>
    public partial class SplitRoom2 : UserControl
    {
        private RoomController roomController = new RoomController();
        public static List<DateTime> busyDates;
        public static DateTime startDate;

        private Room room1;
        private string newId1;
        private string newName1;
        private RoomType newType1;
        private string newId2;
        private string newName2;
        private RoomType newType2;
        public SplitRoom2(Room _room1, string _newId1, string _newName1, RoomType _newType1, string _newId2, string _newName2, RoomType _newType2)
        {
            InitializeComponent();
            this.DataContext = this;

            room1 = _room1;
            newId1 = _newId1;
            newName1 = _newName1;
            newType1 = _newType1;
            newId2 = _newId2;
            newName2 = _newName2;
            newType2 = _newType2;

            BlackoutBusyDaysInCalendar();
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
            EnableOrDisableSaveBtn();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Content = new SplitRooms1(room1, newId1, newName1, newType1, newId2, newName2, newType2);
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            Room room2 = new Room(newId1, newName1, newType1, room1.Floor);
            Room room3 = new Room(newId2, newName2, newType2, room1.Floor);
            roomController.SchedulingAdvancedRenovation(new AdvancedRenovation(RenovationType.split, startDate, int.Parse(Duration.Text), room1, room2, room3));
            this.Content = new ManagerHomePage();
       
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            startDate = (DateTime)Calendar.SelectedDate;
            EnableOrDisableSaveBtn();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
         
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void EnableOrDisableSaveBtn()
        {
            if (EnableSaveBtn())
            {
                ScheduleBtn.IsEnabled = true;
            }
            else
            {
                ScheduleBtn.IsEnabled = false;
            }
        }

        private bool EnableSaveBtn()
        {
            return !string.IsNullOrEmpty(Duration.Text) && !string.IsNullOrEmpty(Calendar.SelectedDate.ToString()) && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MaxDurationValidationRule.ValidationHasError;
        }

        private void BlackoutBusyDaysInCalendar()
        {
            busyDates = roomController.GetBusyDates(room1.Id);
            foreach (DateTime day in busyDates)
            {
                Calendar.BlackoutDates.Add(new CalendarDateRange(day, day));
            }
        }
    }
}

