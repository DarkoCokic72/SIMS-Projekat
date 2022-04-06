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
using FileHandler;
using Model;
using Repo;
using Service;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RoomsWindow.xaml
    /// </summary>
    public partial class RoomsWindow : Window
    {
        public static RoomsWindow roomsWindowInstance;
        public static RoomController roomController;

        public RoomsWindow()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            RoomFileHandler fileHandler = new RoomFileHandler();
            RoomRepository repository = new RoomRepository(fileHandler);
            RoomService service = new RoomService(repository);
            roomController = new RoomController(service);
            dgRooms.ItemsSource = roomController.GetAll();

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
            return (Room)dgRooms.SelectedItem; ;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Room room = getSelectedRoom();
            if(!btn.Content.Equals("Create") && room == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }


            if (btn.Content.Equals("Create"))
            {
               
                CreateRoom createRoom = new CreateRoom();
                createRoom.Show();
            }
            else if (btn.Content.Equals("Read"))
            {

                RoomsRead roomsRead = new RoomsRead();
                roomsRead.Show();

            }
            else if (btn.Content.Equals("Edit"))
            {
                if (room.Type == RoomType.Warehouse)
                {
                    MessageBox.Show("The stockroom cannot be edited!", "Error");
                    return;
                }
                RoomsEdit roomsEdit = new RoomsEdit();
                roomsEdit.Show();

            }
            else if (btn.Content.Equals("Delete"))
            {
                if (room.Type == RoomType.Warehouse)
                {
                    MessageBox.Show("The warehouse cannot be deleted!", "Error");
                    return;
                }
                RoomsDelete roomsDelete = new RoomsDelete();
                roomsDelete.Show();
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            roomsWindowInstance = null;
        }

    }
}

