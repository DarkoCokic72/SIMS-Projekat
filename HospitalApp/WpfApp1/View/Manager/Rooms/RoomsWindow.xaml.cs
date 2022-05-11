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
using FileHandler;
using Model;
using Repo;
using Service;
using WpfApp1.View;
using WpfApp1.View.Manager;
using WpfApp1.View.Rooms;

namespace WpfApp1
{
   
    public partial class RoomsWindow : Window
    {
        public static RoomsWindow roomsWindowInstance;
        public static RoomController roomController;
        public ObservableCollection<Room> Rooms { get; set; }
        public static Room SelectedRoom { get; set; }

        public RoomsWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            roomController = new RoomController();
            Rooms = new ObservableCollection<Room>(roomController.GetAll());

        }

        public static RoomsWindow GetRoomsWindow()
        {
            if (roomsWindowInstance == null)
            {
                roomsWindowInstance = new RoomsWindow();

            }

            return roomsWindowInstance;
        }

        public void refreshContentOfGrid()
        {
            dgRooms.ItemsSource = null;
            dgRooms.ItemsSource = roomController.GetAll();

        }

        public Room getSelectedRoom()
        {
            return (Room)dgRooms.SelectedItem; 
        }


        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            roomsWindowInstance = null;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            CreateRoom createRoom = new CreateRoom();
            createRoom.Show();
            Close();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (!CheckIfRoomIsSelected()) return;
            if (SelectedRoom.Type == RoomType.Warehouse)
            {
                MessageBox.Show("The warehouse cannot be edited!", "Error");
                return;
            }
            RoomsEdit roomsEdit = new RoomsEdit();
            roomsEdit.Show();
            Close();

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (!CheckIfRoomIsSelected()) return;
            if (SelectedRoom.Type == RoomType.Warehouse)
            {
                MessageBox.Show("The warehouse cannot be deleted!", "Error");
                return;
            }
            RoomsDelete roomsDelete = new RoomsDelete();
            roomsDelete.Show();
        }

        private void Button_Click_Details(object sender, RoutedEventArgs e)
        {
            if (!CheckIfRoomIsSelected()) return;
            RoomsEquipment roomsEquipment = RoomsEquipment.GetWindow(SelectedRoom.Id);
            roomsEquipment.Show();
            Close();
        }

        private bool CheckIfRoomIsSelected()
        {
            if (SelectedRoom == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return false;
            }
            return true;
        }
    }
}

