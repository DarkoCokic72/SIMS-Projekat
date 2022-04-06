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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CreateRoom.xaml
    /// </summary>
    public partial class CreateRoom : Window 
    {

        public static Boolean addedRoom = false;
        public CreateRoom()
        {
            InitializeComponent();
            DataContext = this;
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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

        private string floorBinding;
        public string FloorBinding
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

        private string typeBinding;
        public string TypeBinding
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


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                RoomsWindow.roomController.Add(room);

                if (addedRoom == true)
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
            if(!string.IsNullOrEmpty(IdBinding) && !string.IsNullOrEmpty(NameBinding) && !string.IsNullOrEmpty(FloorBinding) && !string.IsNullOrEmpty(TypeBinding))
            {
                e.CanExecute = true;
            }
           
        }
    }
}

