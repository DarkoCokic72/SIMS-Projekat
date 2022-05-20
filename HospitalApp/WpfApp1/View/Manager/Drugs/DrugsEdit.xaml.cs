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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using Model;

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsEdit.xaml
    /// </summary>
    public partial class DrugsEdit : UserControl
    {
        DrugController drugController = new DrugController();
        private bool selectedItemChanged = false;
        public DrugsEdit()
        {
            InitializeComponent();
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Name.Text = DrugsWindow.SelectedDrug.Name;
            Manufacturer.Text = DrugsWindow.SelectedDrug.Manufacturer;
            Ingredients.Text = DrugsWindow.SelectedDrug.Ingredients;
            ComboBox_Replacement.ItemsSource = FillComboBoxWithDrugs();
            if (!string.IsNullOrEmpty(DrugsWindow.SelectedDrug.Replacement))
            {
                ComboBox_Replacement.SelectedItem = DrugsWindow.SelectedDrug.Replacement;
            }

            SaveBtn.IsEnabled = false;
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (!drugController.Update(new Drug(DrugsWindow.SelectedDrug.Id, Name.Text, 0, EquipmentType.drug, null, Manufacturer.Text, Ingredients.Text, (string)ComboBox_Replacement.SelectedItem, true, null), DrugsWindow.SelectedDrug.Name))
            {
                MessageBox.Show("Drug with that name already exists");
                return;
            }
            this.Content = new DrugsWindow();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsEditReason();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableOrDisableSaveBtn();
        }

        private void ComboBox_Replacement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItemChanged = true;
            EnableOrDisableSaveBtn();
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
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

        private void EnableOrDisableSaveBtn()
        {
            if (Name.Text != DrugsWindow.SelectedDrug.Name || Manufacturer.Text != DrugsWindow.SelectedDrug.Manufacturer || Ingredients.Text != DrugsWindow.SelectedDrug.Ingredients)
            {
                SaveBtn.IsEnabled = true;
            }
            else if(!string.IsNullOrEmpty(DrugsWindow.SelectedDrug.Replacement))
            {
                if((string)ComboBox_Replacement.SelectedItem != DrugsWindow.SelectedDrug.Replacement)
                {
                    SaveBtn.IsEnabled = true;
                }
            }
            else if(string.IsNullOrEmpty(DrugsWindow.SelectedDrug.Replacement) && selectedItemChanged == true)
            {
                selectedItemChanged = false;
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }
        }
    }
}
