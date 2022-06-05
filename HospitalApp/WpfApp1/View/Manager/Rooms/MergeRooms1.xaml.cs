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
using Model;

namespace WpfApp1.View.Manager.Rooms
{
    public partial class MergeRooms1 : UserControl
    {
        private readonly RoomController roomController = new RoomController();
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

        private ObservableCollection<RoomType> RoomTypeBinding { get; set; }

        public MergeRooms1(Room _room1, Room _room2, string _newId, RoomType _newType)
        {
            InitializeComponent();
            this.DataContext = this;

            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;

            Room1.ItemsSource = FillComboBoxWithRoomsId();
            Room2.ItemsSource = FillComboBoxWithRoomsId();
            RoomTypeBinding = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>());
            RoomTypeBinding.Remove(RoomType.Warehouse);
            ComboBox.ItemsSource = RoomTypeBinding;
            ComboBox.SelectedItem = RoomType.ExaminationRoom;
            NextBtn.IsEnabled = false;
            Validation.IdValidationRule.ValidationHasError = false;

            if(_room1 != null) 
            {
                Room1.SelectedItem = _room1.Id;
                Room2.SelectedItem = _room2.Id;
                IdBinding = _newId;
                ComboBox.SelectedItem = _newType;
            }
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            this.Content = new MergeRooms2(roomController.GetById((string)Room1.SelectedItem), roomController.GetById((string)Room2.SelectedItem),
                                                      Id.Text, (RoomType)ComboBox.SelectedItem);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            List<string> roomsId = FillComboBoxWithRoomsId();
            roomsId.Remove(Room1.SelectedItem.ToString());
            Room selectedRoom = roomController.GetById(Room1.SelectedItem.ToString());
            roomsId = RemoveRoomsNotAtSameFloor(roomsId, selectedRoom);
            Room2.ItemsSource = roomsId;
            EnableOrDisableNextButton();
        }
        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            List<string> roomsId = FillComboBoxWithRoomsId();
            roomsId.Remove(Room2.SelectedItem.ToString());
            Room selectedRoom = roomController.GetById(Room2.SelectedItem.ToString());
            roomsId = RemoveRoomsNotAtSameFloor(roomsId, selectedRoom);
            Room1.ItemsSource = roomsId;
            EnableOrDisableNextButton();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableNextButton();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableNextButton();
        }

        private List<string> FillComboBoxWithRoomsId()
        {
            List<string> roomsId = new List<string>();
            foreach (Room room in roomController.GetAll())
            {

                if (room.Type != RoomType.Warehouse)
                {
                    roomsId.Add(room.Id);
                }
            }

            return roomsId;
        }

        private void EnableOrDisableNextButton()
        {
            if (EnableNextBtn())
            {
                NextBtn.IsEnabled = true;
            }
            else
            {
                NextBtn.IsEnabled = false;
            }
        }

        private bool EnableNextBtn()
        {
            return !string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem)
                    && !string.IsNullOrEmpty((string)Room2.SelectedItem) && !Validation.RoomIdMergeSplitValidationRule.ValidationHasError;
        }

        private List<string> RemoveRoomsNotAtSameFloor(List<string> allRooms, Room selectedRoom)
        {
            foreach (Room room in roomController.GetAll())
            {
                if (room.Floor != selectedRoom.Floor)
                {
                    allRooms.Remove(room.Id);
                }
            }

            return allRooms;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
