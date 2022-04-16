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
using Controller;
using Model;
using WpfApp1.View.Rooms;

namespace WpfApp1.View.Manager.Equipment
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : Window
    {
        public EquipmentRelocation()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

            EquipmentController equipmentController = new EquipmentController();
            equipmentController.CreateRelocationRequest(new Relocation(Date.DisplayDate, int.Parse(Quantity.Text), (string)Room.SelectedItem, RoomsEquipment.SelectedEquipment));
            Close();
        }
    }
}
