using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Model;
using WpfApp1.View;
using WpfApp1.View.Manager;
using WpfApp1.View.Manager.Drugs;

namespace WpfApp1.ViewModel.Manager.Drugs
{
    class DrugsEditViewModel : BindableBase
    {
        private readonly DrugController drugController = new DrugController();
        public static MyICommand SaveCommand { get; set; }
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

        public DrugsEditViewModel()
        {
            UserBinding = Login.userAccount.Name + " " + Login.userAccount.Surname;
            ReplacementBinding = new ObservableCollection<string>(FillComboBoxWithDrugs());
            CreateCommands();
            NameBinding = DrugsWindow.SelectedDrug.Name;
            ManufacturerBinding = DrugsWindow.SelectedDrug.Manufacturer;
            IngredientsBinding = DrugsWindow.SelectedDrug.Ingredients;
            SelectedReplacementBinding = DrugsWindow.SelectedDrug.Replacement;
        }

        private List<string> FillComboBoxWithDrugs()
        {
            List<string> drugs = new List<string>();
            drugs.Add("None");
            foreach (Drug drug in drugController.GetAll())
            {
                drugs.Add(drug.Name);
            }

            drugs.Distinct();
            return drugs;
        }

        private void CreateCommands()
        {
            HomePageCommand = new MyICommand(OnHomePage);
            LogOutCommand = new MyICommand(OnLogOut);
            SaveCommand = new MyICommand(OnSave, CanSave);
            CancelCommand = new MyICommand(OnCancel);
        }

        private void OnCancel()
        {
            ManagerHomePage.GetManagerHomePage().Content = new DrugsEditReason(); 
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
            drugController.Update(new Drug(DrugsWindow.SelectedDrug.Id, NameBinding, 0, EquipmentType.drug, null, ManufacturerBinding, IngredientsBinding, SelectedReplacementBinding, true, null));
            ManagerHomePage.GetManagerHomePage().Content = new DrugsWindow();
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(NameBinding.Trim()) && !string.IsNullOrEmpty(ManufacturerBinding) && !string.IsNullOrEmpty(IngredientsBinding) && !Validation.DrugNameValidationRule.ValidationHasError && !Validation.DrugsEditDrugNameValidationRule.ValidationHasError
                   && !Validation.DrugsEditRequiredNameFieldValidationRule.ValidationHasError && !Validation.DrugsEditRequiredManufacturerFieldValidationRule.ValidationHasError && !Validation.DrugsEditRequiredIngredientsFieldValidationRule.ValidationHasError;

        }

    }
}

