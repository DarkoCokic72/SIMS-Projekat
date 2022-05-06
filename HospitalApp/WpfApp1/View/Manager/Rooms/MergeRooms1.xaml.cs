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
using Model;

namespace WpfApp1.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for MergeRooms1.xaml
    /// </summary>
    public partial class MergeRooms1 : Window
    {
        private RoomController roomController = new RoomController();

        public MergeRooms1(Room _room1, Room _room2, string _newId, string _newName, RoomType _newType)
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;

            List<string> roomsId = new List<string>();
            List<Room> rooms = roomController.GetAll();
            foreach(Room r in rooms) 
            {
                if (r.Type != RoomType.Warehouse)
                {
                    roomsId.Add(r.Id);
                }
            }

            Room1.ItemsSource = roomsId;
            Room2.ItemsSource = roomsId;
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            ComboBox.SelectedItem = RoomType.ExaminationRoom;
            NextBtn.IsEnabled = false;
            Validation.IdValidationRule.ValidationHasError = false;

            if(_room1 != null) 
            {
                Room1.SelectedItem = _room1.Id;
                Room2.SelectedItem = _room2.Id;
                IdBinding = _newId;
                Name.Text = _newName;
                ComboBox.SelectedItem = _newType;
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            
            MergeRooms2 mergeRooms2 = new MergeRooms2(roomController.GetById((string)Room1.SelectedItem), roomController.GetById((string)Room2.SelectedItem),
                                                      Id.Text, Name.Text, (RoomType)ComboBox.SelectedItem);
            mergeRooms2.Show();
            Close();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            List<string> roomsId = new List<string>();
            List<Room> rooms = roomController.GetAll();
            foreach (Room r in rooms)
            {

                if (r.Type != RoomType.Warehouse)
                {
                    roomsId.Add(r.Id);
                }

            }
            roomsId.Remove(Room1.SelectedItem.ToString());
            Room room = roomController.GetById(Room1.SelectedItem.ToString());
            foreach (Room r in rooms)
            {
                if (r.Floor != room.Floor)
                {
                    roomsId.Remove(r.Id);

                }
            }
            Room2.ItemsSource = roomsId;

            if (!string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem) 
                && !string.IsNullOrEmpty((string)Room2.SelectedItem) && !Validation.IdValidationRule.ValidationHasError)
            {
                NextBtn.IsEnabled = true;
            }
            else
            {
                NextBtn.IsEnabled = false;
            }
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            List<string> roomsId = new List<string>();
            List<Room> rooms = roomController.GetAll();
            foreach (Room r in rooms)
            {

                if (r.Type != RoomType.Warehouse)
                {
                    roomsId.Add(r.Id);
                }

            }
            roomsId.Remove(Room2.SelectedItem.ToString());
            Room room = roomController.GetById(Room2.SelectedItem.ToString());
            foreach(Room r in rooms) 
            {
                if(r.Floor != room.Floor)
                {
                    roomsId.Remove(r.Id);

                }  
            }
            Room1.ItemsSource = roomsId;

            if (!string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem)
                && !string.IsNullOrEmpty((string)Room2.SelectedItem) && !Validation.IdValidationRule.ValidationHasError)
            {
                NextBtn.IsEnabled = true;
            }
            else
            {
                NextBtn.IsEnabled = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem)
                && !string.IsNullOrEmpty((string)Room2.SelectedItem) && !Validation.IdValidationRule.ValidationHasError)
            {
                NextBtn.IsEnabled = true;
            }
            else 
            {
                NextBtn.IsEnabled = false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem)
                && !string.IsNullOrEmpty((string)Room2.SelectedItem) && !Validation.IdValidationRule.ValidationHasError)
            {
                NextBtn.IsEnabled = true;
            }
            else
            {
                NextBtn.IsEnabled = false;
            }
        }
    }
}
