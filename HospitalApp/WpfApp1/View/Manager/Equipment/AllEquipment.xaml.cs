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
            EquipmentController equipmentController = new EquipmentController();

            Equipment = new ObservableCollection<Model.Equipment>(equipmentController.GetAll());
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();

        }
    }
}
