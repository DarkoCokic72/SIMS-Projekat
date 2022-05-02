using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model;

namespace WpfApp1
{

    public partial class CreateRoom : Window 
    {

        public static Boolean addedRoom = false;
        public CreateRoom()
        {
            InitializeComponent();
            DataContext = this;
            ComboBox.ItemsSource = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
            WindowStartupLocation = WindowStartupLocation.Manual;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Top = 0.192*height;
            Left = 0.25*width;

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

                
                RoomsWindow.roomController.Add(new Room(IdBinding, NameBinding, TypeBinding, FloorBinding));

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
            
            if(!string.IsNullOrEmpty(IdBinding) && !string.IsNullOrEmpty(NameBinding)  && !string.IsNullOrEmpty(Floor.Text) && 
                !Validation.StringToIntegerValidationRule.ValidationHasError && !Validation.MinMaxValidationRule.ValidationHasError && !Validation.IdValidationRule.ValidationHasError)
            {
                e.CanExecute = true;
            }
           
        }

    }
}

