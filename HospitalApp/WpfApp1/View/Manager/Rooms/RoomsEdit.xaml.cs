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
using Model;
using WpfApp1.View;
using WpfApp1.View.Manager;

namespace WpfApp1
{
 
    public partial class RoomsEdit : UserControl, INotifyPropertyChanged
    {

        private Room room;
        private string idBinding;
        public string IdBinding
        {
            get
            {
                return idBinding;
            }
            set
            {
                idBinding = value;
                OnPropertyChanged("IdBinding");
            }
        }


        public RoomsEdit()
        {

            InitializeComponent();
            this.DataContext = this;

            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;

            ComboBox_Type.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            ComboBox_Floor.ItemsSource = CreateRoom.GetFloors();
            room = RoomsWindow.SelectedRoom;
            ComboBox_Type.SelectedItem = room.Type;
            ComboBox_Floor.SelectedItem = room.Floor;
            IdBinding = RoomsWindow.SelectedRoom.Id;

            SaveBtn.IsEnabled = false;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        private void EnableOrDisableSaveBtn()
        {
            if (ComboBox_Floor.SelectedItem != null && ComboBox_Type.SelectedItem != null && ((int)ComboBox_Floor.SelectedItem != room.Floor || (RoomType)ComboBox_Type.SelectedItem != room.Type))
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
            
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = RoomsWindow.GetRoomsWindow();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

            if ((RoomType)ComboBox_Type.SelectedItem == RoomType.Warehouse)
            {
                foreach (Room room in RoomsWindow.roomController.GetAll())
                {
                    if (room.Type == RoomType.Warehouse)
                    {
                        MessageBox.Show("Warehouse already exists!", "Error");
                        return;
                    }
                }
            }

        
            if (RoomsWindow.roomController.Update(new Room(IdBinding, (RoomType)ComboBox_Type.SelectedItem, (int)ComboBox_Floor.SelectedItem)))
            {
                this.Content = RoomsWindow.GetRoomsWindow();
            }
            else
            {
                MessageBox.Show("Room with that Id already exists!", "Error");
            }

        }

      
    }
}
    



