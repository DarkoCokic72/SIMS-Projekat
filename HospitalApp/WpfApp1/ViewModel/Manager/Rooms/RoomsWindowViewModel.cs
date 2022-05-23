using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Controller;
using Model;
using WpfApp1.View;
using WpfApp1.View.Manager;
using WpfApp1.View.Rooms;

namespace WpfApp1.ViewModel
{
    public class RoomsWindowViewModel : BindableBase
    {
        private RoomController roomController = new RoomController();
        public static ObservableCollection<Room> Rooms { get; set; }    
        public static Room SelectedRoom { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand DetailsCommand { get; set; }
        public MyICommand LogOutCommand { get; set; }
        public MyICommand HomePageCommand { get; set; }
        public UserControl CurrentPage { get; set; }

        private string userBinding;
        public string UserBinding
        {
            get
            {
                return userBinding;
            }
            set
            {
                userBinding = value;
                OnPropertyChanged("UserBinding");
            }
        }

        public RoomsWindowViewModel()
        {
            Rooms = new ObservableCollection<Room>(roomController.GetAll());
            UserBinding = Login.userAccount.Name + " " + Login.userAccount.Surname;
            CreateCommands();
        }

        private void CreateCommands()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            DetailsCommand = new MyICommand(OnDetails);
            LogOutCommand = new MyICommand(OnLogOut);
            HomePageCommand = new MyICommand(OnHomePage);
        }

        private void OnAdd()
        {
            RoomsWindow.GetRoomsWindow().Content = new CreateRoom();
            RoomsWindow.roomsWindowInstance = null;
        }

        private void OnEdit()
        {
            if (!CheckIfRoomIsSelected()) return;
            if (SelectedRoom.Type == RoomType.Warehouse)
            {
                MessageBox.Show("The warehouse cannot be edited!");
                return;
            }
            RoomsWindow.GetRoomsWindow().Content = new RoomsEdit();
            RoomsWindow.roomsWindowInstance = null;
        }

        private void OnDelete()
        {
            if (!CheckIfRoomIsSelected()) return;
            if (SelectedRoom.Type == RoomType.Warehouse)
            {
                MessageBox.Show("The warehouse cannot be deleted!");
                return;
            }
            RoomsDelete roomsDelete = new RoomsDelete();
            roomsDelete.ShowDialog();
        }

        private void OnDetails()
        {
            if (!CheckIfRoomIsSelected()) return;
            RoomsWindow.GetRoomsWindow().Content = new RoomsEquipment();
            RoomsWindow.roomsWindowInstance = null;
        }

        private void OnHomePage()
        {
            RoomsWindow.GetRoomsWindow().Content = new ManagerHomePage();
            RoomsWindow.roomsWindowInstance = null;
        }


        private void OnLogOut()
        {
            RoomsWindow.GetRoomsWindow().Content = new Login();
            RoomsWindow.roomsWindowInstance = null;
        }

        private bool CheckIfRoomIsSelected()
        {
            if (SelectedRoom == null)
            {
                MessageBox.Show("You need to select a row!");
                return false;
            }
            return true;
        }

    }
}
