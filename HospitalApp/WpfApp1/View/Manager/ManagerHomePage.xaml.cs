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
using Model;
using WpfApp1.View.Manager.Drugs;
using WpfApp1.View.Manager.Equipment;
using WpfApp1.View.Manager.Rooms;
using WpfApp1.View.Manager.SurveysWindows;

namespace WpfApp1.View.Manager
{
    /// <summary>
    /// Interaction logic for ManagerHomePage.xaml
    /// </summary>
    public partial class ManagerHomePage : UserControl
    {
        private static ManagerHomePage managerHomePageInstance = null;
        public ManagerHomePage()
        {
            InitializeComponent();
            
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            DrugsWindow.SelectedDrug = null;
            RoomsWindow.SelectedRoom = null;
        }

        public static ManagerHomePage GetManagerHomePage()
        {
            if(managerHomePageInstance == null)
            {
                managerHomePageInstance = new ManagerHomePage();
            }

            return managerHomePageInstance;
        }

        private void Button_Click_Rooms(object sender, RoutedEventArgs e)
        {
            this.Content = RoomsWindow.GetRoomsWindow();   
        }

        private void Button_Click_Equipment(object sender, RoutedEventArgs e)
        {
            this.Content = new AllEquipment();   
        }

        private void MenuItem_SchedulingRenovation(object sender, RoutedEventArgs e)
        {
            this.Content = new BasicRenovation1(null, null);
           
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            App.CheckNotification = true;
            this.Content = new Login();
        }

        private void MenuItem_Drugs(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsWindow();
            
        }

        private void MenuItem_SchedulingMerge(object sender, RoutedEventArgs e)
        {
            this.Content = new MergeRooms1(null, null, null, RoomType.Warehouse);
        }

        private void MenuItem_SchedulingSplit(object sender, RoutedEventArgs e)
        {
            this.Content = new SplitRooms1(null, null, RoomType.Warehouse, null, RoomType.Warehouse);
            
        }

        private void Button_Click_Hospital(object sender, RoutedEventArgs e)
        {
            this.Content = new HospitalSurveysCategories();
        }

        private void Button_Click_Doctors(object sender, RoutedEventArgs e)
        {
            ChooseDoctor chooseDoctor = new ChooseDoctor();
            chooseDoctor.ShowDialog();
        }
    }
}
