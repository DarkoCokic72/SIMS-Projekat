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
using Model;
using WpfApp1.Model;
using WpfApp1.View.Manager;
using WpfApp1.View.Manager.Equipment;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.Manager.Rooms;

namespace WpfApp1.View.Rooms
{
    /// <summary>
    /// Interaction logic for RoomsEquipment.xaml
    /// </summary>
    public partial class RoomsEquipment : UserControl
    {
        public RoomsEquipment()
        {
            InitializeComponent();
            this.DataContext = new RoomsEquipmentViewModel();
        }
    }
}
