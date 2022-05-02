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
using Model;
using WpfApp1.Model;
using WpfApp1.View.Manager.Equipment;

namespace WpfApp1.View.Rooms
{
    /// <summary>
    /// Interaction logic for RoomsEquipment.xaml
    /// </summary>
    public partial class RoomsEquipment : Window
    {
        public static RoomsEquipment roomsEquipmentWindowInstance;
        public static ObservableCollection<Equipment> Equipment { get; set; }
        public static Equipment SelectedEquipment { get; set; }
        public RoomsEquipment(string roomId)
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.Manual;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Top = 0.192 * height;
            Left = 0.25 * width;


            List<Equipment> e = RoomsWindow.roomController.getEquipment(roomId);
            Equipment = new ObservableCollection<Equipment>(e);
            
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
            roomsEquipmentWindowInstance = null;
        }

        private void Button_Click_Relocation(object sender, RoutedEventArgs e)
        {

            if(SelectedEquipment == null)
            {
                return;
            }
            EquipmentRelocation equipmentRelocationWindow = new EquipmentRelocation();
            equipmentRelocationWindow.Show();
            RoomsWindow.GetRoomsWindow().Close();
            Close();
        }

        public static RoomsEquipment GetWindow(string roomId)
        {
            if (roomsEquipmentWindowInstance == null)
            {
                roomsEquipmentWindowInstance = new RoomsEquipment(roomId);

            }

            return roomsEquipmentWindowInstance;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            roomsEquipmentWindowInstance = null;
        }

        public void refreshContentOfGrid()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = RoomsWindow.roomController.getEquipment(RoomsWindow.SelectedRoom.Id);
        }

    }
}
