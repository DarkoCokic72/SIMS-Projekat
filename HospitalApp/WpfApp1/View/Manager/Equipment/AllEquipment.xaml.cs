using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Controller;

namespace WpfApp1.View.Manager.Equipment
{

    
    public partial class AllEquipment : Window
    {
        public ObservableCollection<Model.Equipment> Equipment { get; set; }
        public AllEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            EquipmentController equipmentController = new EquipmentController();

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

       
    }
}
