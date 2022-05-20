using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DrugsCreate.xaml
    /// </summary>
    public partial class DrugsCreate : UserControl
    {
        private DrugController drugController = new DrugController();
        private RoomController roomController = new RoomController();
        private int quantityBinding;
        public int QuantityBinding
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
        public DrugsCreate()
        {
            InitializeComponent();
            this.DataContext = this;

            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            ComboBox_Replacement.ItemsSource = FillComboBoxWithDrugs();
            SaveBtn.IsEnabled = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content= new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }


        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsWindow();
            
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if(!drugController.Create(new Drug(Name.Text, 100, EquipmentType.drug, roomController.GetById("R1"), Manufacturer.Text, Ingredients.Text, (string)ComboBox_Replacement.SelectedItem, true, null)))
            {
                MessageBox.Show("Drug with that name already exists", "error");
                return;
            }
            this.Content = new DrugsWindow();
               
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void EnableOrDisableSaveBtn()
        {
            if (!string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty(Manufacturer.Text) && !string.IsNullOrEmpty(Ingredients.Text) &&
             !Validation.StringToIntegerValidationRule.ValidationHasError)
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }
        }

        private List<string> FillComboBoxWithDrugs()
        {
            List<string> drugs = new List<string>();
            foreach (Drug drug in drugController.GetAll())
            {
                drugs.Add(drug.Name);
            }

            drugs.Distinct();
            return drugs;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
