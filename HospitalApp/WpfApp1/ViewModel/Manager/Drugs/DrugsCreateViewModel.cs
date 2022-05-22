using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Model;
using WpfApp1.View;
using WpfApp1.View.Manager;
using WpfApp1.View.Manager.Drugs;

namespace WpfApp1.ViewModel.Manager.Drugs
{
    public class DrugsCreateViewModel : BindableBase
    {
        DrugController drugController = new DrugController();
        RoomController roomController = new RoomController();
        public MyICommand SaveCommand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public MyICommand HomePageCommand { get; set; }
        public MyICommand LogOutCommand { get; set; }
        private string userBinding;
        public string UserBinding
        {
            get
            {
                return userBinding;
            }
            set
            {
                userBinding = value;
                OnPropertyChanged("UserBinding");
            }
        }
        private string nameBinding;
        public string NameBinding
        {
            get
            {
                return nameBinding;
            }
            set
            {
                nameBinding = value;
                OnPropertyChanged("NameBinding");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string manufacturerBinding;
        public string ManufacturerBinding
        {
            get
            {
                return manufacturerBinding;
            }
            set
            {
                manufacturerBinding = value;
                OnPropertyChanged("ManufacturerBinding");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string ingredientsBinding;
        public string IngredientsBinding
        {
            get
            {
                return ingredientsBinding;
            }
            set
            {
                ingredientsBinding = value;
                OnPropertyChanged("IngredientsBinding");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string selectedReplacementBinding;
        public string SelectedReplacementBinding
        {
            get
            {
                return selectedReplacementBinding;
            }
            set
            {
                selectedReplacementBinding = value;
                OnPropertyChanged("SelectedReplacementBinding");
            }
        }

        public ObservableCollection<string> ReplacementBinding { get; set; }

        public DrugsCreateViewModel()
        {
            UserBinding = Login.userAccount.Name + " " + Login.userAccount.Surname;
            ReplacementBinding = new ObservableCollection<string>(FillComboBoxWithDrugs());
            HomePageCommand = new MyICommand(OnHomePage);
            LogOutCommand = new MyICommand(OnLogOut);
            SaveCommand = new MyICommand(OnSave, CanSave);
            CancelCommand = new MyICommand(OnCancel);
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

        private void OnCancel()
        {
            ManagerHomePage.GetManagerHomePage().Content = new DrugsWindow();
        }

        private void OnLogOut()
        {
            ManagerHomePage.GetManagerHomePage().Content = new Login();
        }

        private void OnHomePage()
        {
            ManagerHomePage.GetManagerHomePage().Content = new ManagerHomePage();
        }

        private void OnSave()
        {
            if (!drugController.Create(new Drug(NameBinding, 100, EquipmentType.drug, roomController.GetById("R1"), ManufacturerBinding, IngredientsBinding, SelectedReplacementBinding, true, null)))
            {
                MessageBox.Show("Drug with that name already exists", "error");
                return;
            }
            ManagerHomePage.GetManagerHomePage().Content = new DrugsWindow();
        }

        private bool CanSave()
        {
            if (!string.IsNullOrEmpty(NameBinding) && !string.IsNullOrEmpty(ManufacturerBinding) && !string.IsNullOrEmpty(IngredientsBinding))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

}
}

