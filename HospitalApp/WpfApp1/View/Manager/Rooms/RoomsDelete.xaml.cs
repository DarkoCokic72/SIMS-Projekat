using System;
using System.Collections.Generic;
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
using Model;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.Manager.Rooms;

namespace WpfApp1
{
    
    public partial class RoomsDelete : Window
    {
        public RoomsDelete()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            Room room = RoomsWindowViewModel.SelectedRoom;
            RoomsWindow.roomController.Remove(room.Id);
            RoomsWindow.GetRoomsWindow().refreshContentOfGrid();
            Close();
        }

        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
