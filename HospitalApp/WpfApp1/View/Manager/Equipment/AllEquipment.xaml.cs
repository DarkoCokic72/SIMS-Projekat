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
            EquipmentController equipmentController = new EquipmentController();

            List<Model.Equipment> equipmentByRooms = equipmentController.GetAll();
            List<Model.Equipment> allEquipment = new List<Model.Equipment>();
            bool exists = false;

            foreach (Model.Equipment e1 in equipmentByRooms)
            {
                exists = false;
                foreach(Model.Equipment e2 in allEquipment)
                {
                    if(e1.Id == e2.Id)
                    {
                        e2.Quantity += e1.Quantity;
                        exists = true;
                    }
                }

                if (!exists)
                {
                    allEquipment.Add(e1);
                }
            }

             Equipment = new ObservableCollection<Model.Equipment>(allEquipment);
         
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
