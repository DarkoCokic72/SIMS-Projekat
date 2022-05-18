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
using WpfApp1.Validation;
using WpfApp1.View.Rooms;

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
            Info.Text = "Relocating " + RoomsEquipment.SelectedEquipment.Name + " from room " + RoomsEquipment.SelectedEquipment.Room.Id;
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            EquipmentController equipmentController = new EquipmentController();
            //MaxQuantity.Content = equipmentController.MaxQuantityToRelocate(RoomsEquipment.SelectedEquipment).ToString();
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
                if (RoomsWindow.SelectedRoom.Id != room.Id)
                {
                    roomsId.Add(room.Id);
                }
            }

            return roomsId;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = new RoomsEquipment(RoomsEquipment.SelectedEquipment.Room.Id);
           
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            
            EquipmentController equipmentController = new EquipmentController();
            RoomController roomController = new RoomController();
            equipmentController.CreateRelocationRequest(new Relocation((DateTime)Date.SelectedDate, int.Parse(Quantity.Text), roomController.GetById((string)Room.SelectedItem), RoomsEquipment.SelectedEquipment));

            this.Content = RoomsWindow.GetRoomsWindow();
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

    }
}
