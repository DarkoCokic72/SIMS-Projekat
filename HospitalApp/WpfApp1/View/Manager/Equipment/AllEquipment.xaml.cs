using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Controller;

namespace WpfApp1.View.Manager.Equipment
{
    
    public partial class AllEquipment : UserControl
    {
        private bool useName = false;
        private bool useRoom = false;
        private bool useQuantity = false;
        private string name = null;
        private string room = null;
        private string quantity = null;
        EquipmentController equipmentController = new EquipmentController();
        public ObservableCollection<Model.Equipment> Equipment { get; set; }
        public AllEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;

            Equipment = new ObservableCollection<Model.Equipment>(equipmentController.GetAll());
         
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();      
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            if (useName) name = Name.Text.Trim();
            if (useRoom) room = Room.Text.Trim();
            if (useQuantity) quantity = Quantity.Text.Trim();
            dgEquipment.ItemsSource = null;
            dgEquipment.ItemsSource = new ObservableCollection<Model.Equipment>(equipmentController.SearchEquipment(name, room, quantity));
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NameBoxGotFocus(object sender, RoutedEventArgs e)
        {
            useName = true;
            Name.Text = string.Empty;
            Name.FontStyle = FontStyles.Normal;
            Name.Foreground = new SolidColorBrush(Colors.Black);
            Name.GotFocus -= NameBoxGotFocus;
        }

        private void RoomBoxGotFocus(object sender, RoutedEventArgs e)
        {
            useRoom = true;
            Room.Text = string.Empty;
            Room.FontStyle = FontStyles.Normal;
            Room.Foreground = new SolidColorBrush(Colors.Black);
            Room.GotFocus -= RoomBoxGotFocus;
        }

        private void QuantityBoxGotFocus(object sender, RoutedEventArgs e)
        {
            useQuantity = true;
            Quantity.Text = string.Empty;
            Quantity.FontStyle = FontStyles.Normal;
            Quantity.Foreground = new SolidColorBrush(Colors.Black);
            Quantity.GotFocus -= QuantityBoxGotFocus;
        }
    }
}
