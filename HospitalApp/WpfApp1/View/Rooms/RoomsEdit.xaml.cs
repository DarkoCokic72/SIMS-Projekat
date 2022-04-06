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
    /// Interaction logic for RoomsEdit.xaml
    /// </summary>

    public partial class RoomsEdit : Window
    {
        public static Boolean editedRoom = false;

        public RoomsEdit()
        {
           
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Room room = RoomsWindow.roomsWindowInstance.getSelectedRoom();
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            Id.Text = room.Id;
            Name.Text = room.Name;
            ComboBox.SelectedItem = room.Type;
            Floor.Text = room.Floor.ToString();

            SaveBtn.IsEnabled = false;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            SaveBtn.IsEnabled = true;

        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if(btn.Content.Equals("Cancel"))
            {
                Close();
            }
            else if(btn.Content.Equals("Save"))
            {

                string id = Id.Text;
                string name = Name.Text;
                RoomType type = (RoomType)ComboBox.SelectedItem;

                if (type == RoomType.Warehouse)
                {
                    foreach (Room r in RoomsWindow.roomController.GetAll())
                    {
                        if (r.Type == RoomType.Warehouse)
                        {
                            MessageBox.Show("Warehouse already exists!", "Error");
                            return;
                        }
                    }
                }

                int floor = int.Parse(Floor.Text);
                Room room = new Room(id, name, type, floor);
                RoomsWindow.roomController.Update(room);

                if (editedRoom == true)
                {
                    RoomsWindow.roomsWindowInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Room with that Id already exists!", "Error");
                }


            }
     

        }
    }
}
    



