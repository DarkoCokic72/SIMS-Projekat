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
using WpfApp1.ViewModel;

namespace WpfApp1
{

    public partial class RoomsWindow : UserControl
    {
        public static RoomsWindow roomsWindowInstance;
        public static RoomController roomController = new RoomController();

        public RoomsWindow()
        {
            InitializeComponent();
            this.DataContext = new RoomsWindowViewModel();
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
    }
}


