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
        private readonly DrugController drugController = new DrugController();
        private readonly RoomController roomController = new RoomController();
        public static MyICommand SaveCommand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public MyICommand HomePageCommand { get; set; }
        public MyICommand ProfileCommand { get; set; }
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

        public DrugsCreateViewModel()
        {
            UserBinding = Login.userAccount.Name + " " + Login.userAccount.Surname;
            ReplacementBinding = new ObservableCollection<string>(FillComboBoxWithDrugs());
            CreateCommands();
            SelectedReplacementBinding = "None";
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
            ProfileCommand = new MyICommand(OnProfile);
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

        private void OnProfile()
        {
            ManagerHomePage.GetManagerHomePage().Content = new ManagerProfile();
        }

        private void OnSave()
        {
            drugController.Create(new Drug(NameBinding.Trim(), 100, EquipmentType.drug, roomController.GetById("R1"), ManufacturerBinding, IngredientsBinding, SelectedReplacementBinding, true, null));
            ManagerHomePage.GetManagerHomePage().Content = new DrugsWindow();
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(NameBinding) && !string.IsNullOrEmpty(ManufacturerBinding) && !string.IsNullOrEmpty(IngredientsBinding) && !Validation.DrugNameValidationRule.ValidationHasError
                   && !Validation.RequiredNameFieldValidationRule.ValidationHasError && !Validation.RequiredManufacturerFieldValidationRule.ValidationHasError && !Validation.RequiredIngredientsFieldValidationRule.ValidationHasError;
           
        }

    }
}

