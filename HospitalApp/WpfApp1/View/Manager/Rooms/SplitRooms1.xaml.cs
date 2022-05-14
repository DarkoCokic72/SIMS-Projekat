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
    public partial class SplitRooms1 : Window
    {
        private RoomController roomController = new RoomController();
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

        private string id2Binding;
        public string Id2Binding
        {
            get
            {
                return id2Binding;
            }
            set
            {
                id2Binding = value;
                OnPropertyChanged("Id2Binding");
            }
        }

        public SplitRooms1(Room _room1, string _newId1, string _newName1, RoomType _newType1, string _newId2, string _newName2, RoomType _newType2)
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            FillRoomComboBox();
            FillRoomTypeComboBoxes();
            NextBtn.IsEnabled = false;
            

            if(_room1 != null) 
            {
                Room1.SelectedItem = _room1.Id;
                IdBinding = _newId1;
                Name.Text = _newName1;
                ComboBox.SelectedItem = _newType1;
                Id2Binding = _newId2;
                Name2.Text = _newName2;
                ComboBox2.SelectedItem = _newType2;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableNextBtn();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableNextBtn();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableNextBtn();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (!CheckFirstId() || !CheckSecondId() || !CheckBoth()) return;
            SplitRoom2 splitRoom2 = new SplitRoom2(roomController.GetById((string)Room1.SelectedItem), Id.Text, Name.Text, (RoomType)ComboBox.SelectedItem,
                                                    Id2.Text, Name2.Text, (RoomType)ComboBox2.SelectedItem);
            splitRoom2.Show();
            Close();
        }

        private bool CheckFirstId()
        {
            if (roomController.RoomIdExists(Id.Text))
            {
                MessageBox.Show("The id entered for the first room already exists!", "Error");
                return false;
            }
            return true;
        }

        private bool CheckSecondId()
        {
            if (roomController.RoomIdExists(Id2.Text))
            {
                MessageBox.Show("The id entered for the second room already exists!", "Error");
                return false;
            }
            return true;
        }

        private bool CheckBoth()
        {
            if (Id.Text == Id2.Text)
            {
                MessageBox.Show("Both rooms have same id!", "Error");
                return false;
            }
            return true;
        }

        private void EnableOrDisableNextBtn()
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
            return !string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem)
            && !string.IsNullOrEmpty(Id2.Text) && !string.IsNullOrEmpty(Name2.Text) && !Validation.IdValidationRule.ValidationHasError;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void FillRoomComboBox()
        {
            List<string> roomsId = new List<string>();
            foreach (Room room in roomController.GetAll())
            {
                if (room.Type != RoomType.Warehouse)
                {
                    roomsId.Add(room.Id);
                }
            }

            Room1.ItemsSource = roomsId;
        }

        private void FillRoomTypeComboBoxes()
        {
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            ComboBox.SelectedItem = RoomType.ExaminationRoom;
            ComboBox2.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            ComboBox2.SelectedItem = RoomType.ExaminationRoom;
        }
    }
}
