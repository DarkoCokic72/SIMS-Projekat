﻿using System;
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
using WpfApp1.Validation;
using WpfApp1.View.Rooms;

namespace WpfApp1.View.Manager.Equipment
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : Window
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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            FromRoom.Text = RoomsEquipment.SelectedEquipment.Room;
            EquipmentName.Text = RoomsEquipment.SelectedEquipment.Name;

            EquipmentController equipmentController = new EquipmentController();
            MaxQuantity.Text = equipmentController.MaxQuantityToRelocate(RoomsEquipment.SelectedEquipment).ToString();

            List<Room> rooms = RoomsWindow.roomController.GetAll();
            List<string> roomsId = new List<String>();
            foreach (Room r in rooms)
            {
                if (RoomsWindow.SelectedRoom.Id != r.Id)
                {
                    roomsId.Add(r.Id);
                }
            }

            Room.ItemsSource = roomsId;

            Save.IsEnabled = false;
            MinMaxQuantityValidationRule.ValidationHasError = false;
            StringToIntegerValidationRule.ValidationHasError = false;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            
            EquipmentController equipmentController = new EquipmentController();
            equipmentController.CreateRelocationRequest(new Relocation((DateTime)Date.SelectedDate, int.Parse(Quantity.Text), (string)Room.SelectedItem, RoomsEquipment.SelectedEquipment));
            RoomsEquipment.GetWindow().Close();
            Close();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {

            if(Date.SelectedDate != null && !string.IsNullOrEmpty((string)Room.SelectedItem) && !string.IsNullOrEmpty(Quantity.Text) && !MinMaxQuantityValidationRule.ValidationHasError && !StringToIntegerValidationRule.ValidationHasError)
            {
                Save.IsEnabled = true;
            }
            else
            {
                Save.IsEnabled = false;
            }

        }

        private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
    }
}