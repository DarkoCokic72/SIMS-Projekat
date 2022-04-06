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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RoomsRead.xaml
    /// </summary>
    public partial class RoomsRead : Window
    {
        public RoomsRead()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Room room = RoomsWindow.roomsWindowInstance.getSelectedRoom();
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            Id.Text = room.Id;
            Name.Text = room.Name;
            ComboBox.SelectedItem = room.Type;
            Floor.Text = room.Floor.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
            }


        }
    }
}
