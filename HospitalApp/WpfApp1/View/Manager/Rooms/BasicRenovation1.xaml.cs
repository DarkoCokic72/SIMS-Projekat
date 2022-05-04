using System;
using System.Collections.Generic;
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
    /// Interaction logic for BasicRenovation1.xaml
    /// </summary>
    public partial class BasicRenovation1 : Window
    {

        public BasicRenovation1(string roomId, string description)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            RoomController roomController = new RoomController();
            List<Room> rooms = roomController.GetAll();
            List<string> roomsId = new List<string>();

            foreach (Room r in rooms) {
                roomsId.Add(r.Id);   
            }

            Room.ItemsSource = roomsId;
            NextBtn.IsEnabled = false;

            if (!string.IsNullOrEmpty(roomId) && !string.IsNullOrEmpty(description)) 
            {
                Room.SelectedItem = roomId;
                Description.Text = description;
                NextBtn.IsEnabled = true;

            }
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            BasicRenovation basicRenovationWindow = new BasicRenovation((string)Room.SelectedItem, Description.Text);
            basicRenovationWindow.Show();
            Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Description.Text) && !string.IsNullOrEmpty((string)Room.SelectedItem)) 
            {
                NextBtn.IsEnabled = true;    
            }
            else
            {
                NextBtn.IsEnabled = false;
            }
        }

        private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Description.Text) && !string.IsNullOrEmpty((string)Room.SelectedItem))
            {
                NextBtn.IsEnabled = true;
            }
            else
            {
                NextBtn.IsEnabled = false;
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
