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
using Controller;
using Model;

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsWindow.xaml
    /// </summary>
    public partial class DrugsWindow : Window
    {
        public ObservableCollection<Drug> Drugs { get; set; }
        public static Drug SelectedDrug { get; set; }
        public DrugsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;

            DrugController drugsController = new DrugController();
            Drugs = new ObservableCollection<Drug>(drugsController.GetAll());
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

        private void dgRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            DrugsCreate drugsCreate = new DrugsCreate();
            drugsCreate.Show();
            Close();
        }

        private void Button_Click_Details(object sender, RoutedEventArgs e)
        {
            DrugsDetails.getInstance().ShowDialog();
            
        }
    }
}
