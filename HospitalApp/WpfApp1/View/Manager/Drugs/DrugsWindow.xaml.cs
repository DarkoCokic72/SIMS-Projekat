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
            if(SelectedDrug == null || SelectedDrug.Valid == true)
            {
                MessageBox.Show("Select invalid drug you want to edit.");
                return;
            }

            this.Content = new DrugsEditReason();

        }

        private void ShowFirstInvalidDrugs()
        {
            List<Drug> sortedDrugs = GetInvalidDrugs();
            sortedDrugs.AddRange(GetValidDrugs());
            Drugs = new ObservableCollection<Drug>(sortedDrugs);
        }

        private List<Drug> GetInvalidDrugs()
        {
            List<Drug> invalidDrugs = new List<Drug>();
            foreach (Drug drug in drugsController.GetAll())
            {
                if (!drug.Valid)
                {
                    invalidDrugs.Add(drug);
                }
            }

            return invalidDrugs;
        }

        private List<Drug> GetValidDrugs()
        {
            List<Drug> validDrugs = new List<Drug>();
            foreach (Drug drug in drugsController.GetAll())
            {
                if (drug.Valid)
                {
                    validDrugs.Add(drug);
                }
            }

            return validDrugs;
        }
    }
}
