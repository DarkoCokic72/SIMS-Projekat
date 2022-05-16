using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Model;
using WpfApp1.View.Manager.Equipment;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EquipmentPurhcaseWindow.xaml
    /// </summary>
    public partial class EquipmentPurchaseWindow : Window
    {
        public static EquipmentPurchaseWindow equipmentPurchaseWindowInstance;
        public static ObservableCollection<Equipment> Equipments { get; set; }
        public EquipmentPurchaseWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Equipments = new ObservableCollection<Equipment>(RoomsWindow.roomController.getEquipment("R1"));

            Equipment.ItemsSource = GetWareHouseEquipment();

        }
        private string quantityBinding;
        public string QuantityBinding
        {
            get
            {
                return quantityBinding;
            }
            set
            {
                quantityBinding = value;
                OnPropertyChanged("QuantityBinding");
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

        private List<Equipment> GetWareHouseEquipment()
        {
            EquipmentController equipmentController = new EquipmentController();
            List<Equipment> equipments = equipmentController.GetAll();
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in equipments)
                if (equipment.Room.Id == "R1")
                {
                    equipmentList.Add(equipment);
                }
            return equipmentList;
        }

        public static EquipmentPurchaseWindow GetEquipmentPurchaseWindow()
        {
            if (equipmentPurchaseWindowInstance == null)
            {
                equipmentPurchaseWindowInstance = new EquipmentPurchaseWindow();
            }
            return equipmentPurchaseWindowInstance;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Cancel"))
            {
                Close();
            }
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Save"))
            {
                
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(QuantityBinding))
            {
                e.CanExecute = true;
            }
        }
    }
}
