using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Controller;

namespace WpfApp1.View.Manager.Equipment
{

    
    public partial class AllEquipment : Window
    {
        EquipmentController equipmentController = new EquipmentController();
        public ObservableCollection<Model.Equipment> Equipment { get; set; }
        public AllEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;

            Equipment = new ObservableCollection<Model.Equipment>(equipmentController.GetAll());
         
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

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            dgEquipment.ItemsSource = null;
            dgEquipment.ItemsSource = new ObservableCollection<Model.Equipment>(equipmentController.SearchEquipment(Name.Text, Quantity.Text));
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
