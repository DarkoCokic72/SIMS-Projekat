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
    public partial class DrugsWindow : UserControl
    {
        private DrugController drugsController = new DrugController();
        public ObservableCollection<Drug> Drugs { get; set; }
        public static Drug SelectedDrug { get; set; }
        public DrugsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            ShowFirstInvalidDrugs();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsCreate();
        }

        private void Button_Click_Details(object sender, RoutedEventArgs e)
        {
            DrugsDetails drugsDetails = new DrugsDetails();
            drugsDetails.ShowDialog();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if(SelectedDrug == null)
            {
                MessageBox.Show("Select invalid drug you want to edit.");
                return;
            }

            if(SelectedDrug.Valid == true)
            {
                MessageBox.Show("You can only edit invalid drug.");
                return;
            }

            this.Content = new DrugsEditReason();

        }

        private void ShowFirstInvalidDrugs()
        {
            List<Drug> allDrugs = drugsController.GetAll();
            List<Drug> sortedDrugs = new List<Drug>();
            foreach(Drug drug in allDrugs)
            {
                if (!drug.Valid)
                {
                    sortedDrugs.Add(drug);
                }
            }
            foreach(Drug drug in allDrugs)
            {
                if (drug.Valid)
                {
                    sortedDrugs.Add(drug);
                }
            }
            Drugs = new ObservableCollection<Drug>(sortedDrugs);
        }
    }
}
