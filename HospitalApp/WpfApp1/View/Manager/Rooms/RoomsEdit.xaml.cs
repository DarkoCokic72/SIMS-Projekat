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
using WpfApp1.View.Manager;

namespace WpfApp1
{
 
    public partial class RoomsEdit : Window, INotifyPropertyChanged
    {
        public static Boolean editedRoom = false;
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



        public RoomsEdit()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
           
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            room = RoomsWindow.roomsWindowInstance.getSelectedRoom();
            IdBinding = room.Id;
            NameBinding= room.Name;
            TypeBinding = room.Type;
            FloorBinding = room.Floor;

            Validation.MinMaxValidationRule.ValidationHasError = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
            Validation.IdValidationRule.ValidationHasError = false;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (IdBinding == room.Id && NameBinding == room.Name && FloorBinding == room.Floor)
            {
                 SaveBtn.IsEnabled = false;      
            }
            else if(string.IsNullOrEmpty(IdBinding) || string.IsNullOrEmpty(NameBinding) || string.IsNullOrEmpty(Floor.Text))
            {
                SaveBtn.IsEnabled = false;
            }
            else if(Validation.StringToIntegerValidationRule.ValidationHasError || Validation.MinMaxValidationRule.ValidationHasError || Validation.IdValidationRule.ValidationHasError)
            {
                SaveBtn.IsEnabled = false;
            }
            else
            {
                SaveBtn.IsEnabled = true;
            }
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if(btn.Content.Equals("Cancel"))
            {
                RoomsWindow.GetRoomsWindow().Show();
                Close();
            }
            else if(btn.Content.Equals("Save"))
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

                RoomsWindow.roomController.Update(new Room(IdBinding, NameBinding, TypeBinding, FloorBinding));

                if (editedRoom == true)
                {
                    RoomsWindow.roomsWindowInstance.refreshContentOfGrid();
                    RoomsWindow.GetRoomsWindow().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Room with that Id already exists!", "Error");
                }


            }
     
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((RoomType)ComboBox.SelectedItem != room.Type && !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MinMaxValidationRule.ValidationHasError && !Validation.IdValidationRule.ValidationHasError)
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
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();

        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
    



