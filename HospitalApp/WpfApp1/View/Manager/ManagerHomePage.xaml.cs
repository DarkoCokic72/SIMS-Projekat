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
using WpfApp1.View.Manager.Equipment;
using WpfApp1.View.Manager.Rooms;

namespace WpfApp1.View.Manager
{
    /// <summary>
    /// Interaction logic for ManagerHomePage.xaml
    /// </summary>
    public partial class ManagerHomePage : Window
    {
   
        public ManagerHomePage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_Rooms(object sender, RoutedEventArgs e)
        {

            RoomsWindow roomsWindow = RoomsWindow.GetRoomsWindow();
            roomsWindow.Show();
            Close();

        }

        private void Button_Click_Equipment(object sender, RoutedEventArgs e)
        {
            AllEquipment allEquipmentWindow = new AllEquipment();
            allEquipmentWindow.Show();
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BasicRenovation1 basicRenovationWindow = new BasicRenovation1();
            basicRenovationWindow.Show();
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
