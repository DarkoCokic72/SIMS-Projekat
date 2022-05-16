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
using WpfApp1.View.Manager.Drugs;
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
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
        }

        private void Button_Click_Rooms(object sender, RoutedEventArgs e)
        {
            RoomsWindow.GetRoomsWindow().Show();
            Close();
        }

        private void Button_Click_Equipment(object sender, RoutedEventArgs e)
        {
            AllEquipment allEquipmentWindow = new AllEquipment();
            allEquipmentWindow.Show();
            Close();
        }

        private void MenuItem_SchedulingRenovation(object sender, RoutedEventArgs e)
        {
            BasicRenovation1 basicRenovationWindow = new BasicRenovation1(null, null);
            basicRenovationWindow.Show();
            Close();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            App.CheckNotification = true;
            Close();
        }

        private void MenuItem_Drugs(object sender, RoutedEventArgs e)
        {
            DrugsWindow drugsWindow = new DrugsWindow();
            drugsWindow.Show();
            Close();
        }

        private void MenuItem_SchedulingMerge(object sender, RoutedEventArgs e)
        {
            MergeRooms1 mergeRooms1 = new MergeRooms1(null, null, null, null, RoomType.Warehouse);
            mergeRooms1.Show();
            Close();
        }

        private void MenuItem_SchedulingSplit(object sender, RoutedEventArgs e)
        {
            SplitRooms1 splitRooms1 = new SplitRooms1(null, null, null, RoomType.Warehouse, null, null, RoomType.Warehouse);
            splitRooms1.Show();
            Close();
        }
    }
}
