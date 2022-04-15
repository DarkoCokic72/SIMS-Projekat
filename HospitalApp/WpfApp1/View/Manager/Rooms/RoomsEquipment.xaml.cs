using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
namespace WpfApp1.View.Rooms
{
    /// <summary>
    /// Interaction logic for RoomsEquipment.xaml
    /// </summary>
    public partial class RoomsEquipment : Window
    {
        public System.Collections.ArrayList Equipment { get; set; }
        public RoomsEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Equipment = RoomsWindow.SelectedRoom.GetEquipment();
            
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Relocation(object sender, RoutedEventArgs e)
        {

        }
    }
}
