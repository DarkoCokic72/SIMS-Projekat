using System.Threading;
using System.Windows;
using Controller;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static EquipmentController equipmentController = new EquipmentController();
        public static Thread RelocationThread = new Thread(() =>
        {
            while (true)
            {
                equipmentController.Relocate();
            }
        });
        private static RoomController roomController = new RoomController();
        public static Thread RenovationThread = new Thread(() =>
        {
            while (true)
            {
                roomController.Renovate();
            }
        });
    }
}
