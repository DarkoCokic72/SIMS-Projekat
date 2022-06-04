using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Controller;
using Model;
using WpfApp1.Validation;
using WpfApp1.View.Rooms;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.Manager.Rooms;

namespace WpfApp1.View.Manager.Equipment
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : UserControl
    {

        private int quantityTest;
        public int QuantityTest
        {
            get
            {
                return quantityTest;
            }
            set
            {
                quantityTest = value;
                OnPropertyChanged("QuantityTest");
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
        public EquipmentRelocation()
        {
         
            InitializeComponent();
            this.DataContext = this;
            Info.Text = "Relocating " + ViewModel.Manager.Rooms.RoomsEquipmentViewModel.SelectedEquipment.Name + " from room " + ViewModel.Manager.Rooms.RoomsEquipmentViewModel.SelectedEquipment.Room.Id;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            EquipmentController equipmentController = new EquipmentController();
            QuantityTest = equipmentController.MaxQuantityToRelocate(ViewModel.Manager.Rooms.RoomsEquipmentViewModel.SelectedEquipment);
            Room.ItemsSource = FillComboBoxWithRooms();

            Save.IsEnabled = false;
            MinMaxQuantityValidationRule.ValidationHasError = false;
            StringToIntegerValidationRule.ValidationHasError = false;
        }

        private List<string> FillComboBoxWithRooms()
        {
            List<string> roomsId = new List<String>();
            foreach (Room room in RoomsWindow.roomController.GetAll())
            {
                if (RoomsWindowViewModel.SelectedRoom.Id != room.Id)
                {
                    roomsId.Add(room.Id);
                }
            }

            return roomsId;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = new RoomsEquipment();   
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            
            EquipmentController equipmentController = new EquipmentController();
            RoomController roomController = new RoomController();
            equipmentController.CreateRelocationRequest(new Relocation((DateTime)Date.SelectedDate, int.Parse(Quantity.Text), roomController.GetById((string)Room.SelectedItem), ViewModel.Manager.Rooms.RoomsEquipmentViewModel.SelectedEquipment));

            this.Content = RoomsWindow.GetRoomsWindow();
            if (((DateTime)Date.SelectedDate).ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                new SuccessfulActionWindow("Equipment was moved!");
            }
            else
            {
                new SuccessfulActionWindow("Relocation request was created");
            }
        }

        private void EnableOrDisableSaveBtn()
        {
            if (Date.SelectedDate != null && !string.IsNullOrEmpty((string)Room.SelectedItem) && !string.IsNullOrEmpty(Quantity.Text) && !MinMaxQuantityValidationRule.ValidationHasError && !StringToIntegerValidationRule.ValidationHasError)
            {
                Save.IsEnabled = true;
            }
            else
            {
                Save.IsEnabled = false;
            }

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();           
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
