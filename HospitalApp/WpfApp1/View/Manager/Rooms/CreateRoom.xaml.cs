using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model;
using WpfApp1.View;
using WpfApp1.View.Manager;

namespace WpfApp1
{

    public partial class CreateRoom : Window 
    {

        public CreateRoom()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;

            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            Validation.MinMaxValidationRule.ValidationHasError = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
            Validation.IdValidationRule.ValidationHasError = false;
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

        private string nameBinding;
        public string NameBinding
        {
            get
            {
                return nameBinding;
            }
            set
            {
                nameBinding = value;
                OnPropertyChanged("NameBinding");
            }
        }

        private int floorBinding;
        public int FloorBinding
        {
            get
            {
                return floorBinding;
            }
            set
            {
                floorBinding = value;
                OnPropertyChanged("FloorBinding");
            }
        }

        private RoomType typeBinding;
        public RoomType TypeBinding
        {
            get
            {
                return typeBinding;
            }
            set
            {
                typeBinding = value;
                OnPropertyChanged("TypeBinding");
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

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            
            if(!string.IsNullOrEmpty(IdBinding) && !string.IsNullOrEmpty(NameBinding)  && !string.IsNullOrEmpty(Floor.Text) && 
                !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MinMaxValidationRule.ValidationHasError && !Validation.IdValidationRule.ValidationHasError)
            {
                e.CanExecute = true;
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
            RoomsWindow.GetRoomsWindow().Show();
            Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            
            if (TypeBinding == RoomType.Warehouse)
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

            if (RoomsWindow.roomController.Add(new Room(IdBinding, NameBinding, TypeBinding, FloorBinding)))
            {
                RoomsWindow.GetRoomsWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Room with that Id already exists!", "Error");
            }
            
        }
    }
}

