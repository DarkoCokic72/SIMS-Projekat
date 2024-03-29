﻿using System;
using System.Collections.Generic;
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
using WpfApp1.Controller;

namespace WpfApp1.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for MergeRooms2.xaml
    /// </summary>
    public partial class MergeRooms2 : UserControl
    {
        private readonly RoomController roomController = new RoomController();
        private readonly RenovationController renovationController = new RenovationController();
        public static List<DateTime> busyDates;
        public static DateTime startDate;

        private Room room1;
        private Room room2;
        private string newId;
        private RoomType newType;

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

        public MergeRooms2(Room _room1, Room _room2, string _newId, RoomType _newType)
        {
            InitializeComponent();
            this.DataContext = this;
            DurationBinding = 1;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;

            room1 = _room1;
            room2 = _room2;
            newId = _newId;
            newType = _newType;

            BlackoutBusyDaysInCalendar();
            ScheduleBtn.IsEnabled = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
            Validation.MaxDurationRoomsMergeValidationRule.ValidationHasError = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableScheduleBtn();
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Content = new MergeRooms1(room1, room2, newId, newType);
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            Room room3 = new Room(newId, newType, room1.Floor);
            renovationController.SchedulingAdvancedRenovation(new AdvancedRenovation(RenovationType.merge, startDate, int.Parse(Duration.Text), room1, room2, room3));
            this.Content = new ManagerHomePage();
            new SuccessfulActionWindow("Rooms merge is scheduled!");
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            startDate = (DateTime)Calendar.SelectedDate;
            BindingExpression binding = Duration.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            EnableOrDisableScheduleBtn();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void EnableOrDisableScheduleBtn()
        {
            if (EnableScheduleBtn())
            {
                ScheduleBtn.IsEnabled = true;
            }
            else
            {
                ScheduleBtn.IsEnabled = false;
            }
        }

        private bool EnableScheduleBtn()
        {
            return !string.IsNullOrEmpty(Duration.Text) && !string.IsNullOrEmpty(Calendar.SelectedDate.ToString()) && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MaxDurationRoomsMergeValidationRule.ValidationHasError;
        }

        private void BlackoutBusyDaysInCalendar()
        {
            busyDates = roomController.GetBusyDates(room1.Id);
            busyDates.AddRange(roomController.GetBusyDates(room2.Id));

            foreach (DateTime day in busyDates)
            {
                Calendar.BlackoutDates.Add(new CalendarDateRange(day, day));
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

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
