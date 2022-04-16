using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Service;
using WpfApp1.View.Manager;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Thread Thread { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            startRelocationThread();    
        }

        public static void startRelocationThread()
        {
            EquipmentService equipmentService = new EquipmentService();
            Thread = new Thread(equipmentService.Relocate);
            Thread.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Thread.Abort();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Manager"))
            {
                ManagerHomePage managerHomePage = new ManagerHomePage();
                managerHomePage.Show();
            }
        }
    }
}
