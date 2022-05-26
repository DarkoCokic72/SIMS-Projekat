using System;
using System.Collections;
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
    public partial class SplitRooms1 : UserControl, INotifyPropertyChanged
    {
        private readonly RoomController roomController = new RoomController();
        public static string idBinding;
        public string IdBinding
        {
            get
            {
                return idBinding;
            }
            set
            {
                if (value != null) idBinding = value.Trim();
                else idBinding = value;
                OnPropertyChanged("IdBinding");
            }
        }

        public static string id2Binding;
        public string Id2Binding
        {
            get
            {
                return id2Binding;
            }
            set
            {
                if (value != null) id2Binding = value.Trim();
                else id2Binding = value;
                OnPropertyChanged("Id2Binding");
            }
        }

        public ObservableCollection<RoomType> RoomTypeBinding { get; set; }

        public SplitRooms1(Room _room1, string _newId1, RoomType _newType1, string _newId2, RoomType _newType2)
        {
            InitializeComponent();
            this.DataContext = this;

            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            FillRoomComboBox();
            FillRoomTypeComboBoxes();
            NextBtn.IsEnabled = false;

            Id2Binding = _newId2;
            IdBinding = _newId1;
            if (_room1 != null) 
            {
                Room1.SelectedItem = _room1.Id;
                ComboBox.SelectedItem = _newType1;
                ComboBox2.SelectedItem = _newType2;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression binding = Id2.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            BindingExpression binding2 = Id.GetBindingExpression(TextBox.TextProperty);
            binding2.UpdateSource();
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
            this.Content = new ManagerHomePage();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (!CheckFirstId() || !CheckSecondId() || !CheckBoth()) return;
            this.Content = new SplitRoom2(roomController.GetById((string)Room1.SelectedItem), Id.Text, (RoomType)ComboBox.SelectedItem,
                                                    Id2.Text, (RoomType)ComboBox2.SelectedItem);
            
           
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
            return !string.IsNullOrEmpty(Id.Text) && !string.IsNullOrEmpty((string)Room1.SelectedItem) && !Validation.RoomIdMergeSplitValidationRule2.ValidationHasError
            && !string.IsNullOrEmpty(Id2.Text) && !Validation.RoomIdMergeSplitValidationRule.ValidationHasError && !Validation.SameIdMergeSplitValidationRule.ValidationHasError;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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
            RoomTypeBinding = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>());
            RoomTypeBinding.Remove(RoomType.Warehouse);
            ComboBox.ItemsSource = RoomTypeBinding;
            ComboBox.SelectedItem = RoomType.ExaminationRoom;
            ComboBox2.ItemsSource = RoomTypeBinding;
            ComboBox2.SelectedItem = RoomType.ExaminationRoom;
        }
    }
}
