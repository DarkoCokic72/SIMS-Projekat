using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.View;
using WpfApp1.View.Manager;
using WpfApp1.View.Manager.Equipment;

namespace WpfApp1.ViewModel.Manager.Rooms
{
    public class RoomsEquipmentViewModel : BindableBase
    {
        public static ObservableCollection<Equipment> Equipment { get; set; }
        public static Equipment SelectedEquipment { get; set; }
        public MyICommand LogOutCommand { get; set; }
        public MyICommand HomePageCommand { get; set; }
        public MyICommand ProfileCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        public MyICommand RelocateCommand { get; set; }
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

        private string idBinding;
        public string IdBinding
        {
            get
            {
                return idBinding;
            }
            set
            {
                idBinding = value;
            }
        }
        public RoomsEquipmentViewModel()
        {
            SelectedEquipment = null;
            UserBinding = Login.userAccount.Name + " " + Login.userAccount.Surname;
            IdBinding = RoomsWindowViewModel.SelectedRoom.Id;
            Equipment = new ObservableCollection<Equipment>(RoomsWindow.roomController.GetEquipment(RoomsWindowViewModel.SelectedRoom.Id));
            CreateCommands();
        }

        private void CreateCommands()
        {
            LogOutCommand = new MyICommand(OnLogOut);
            HomePageCommand = new MyICommand(OnHomePage);
            BackCommand = new MyICommand(OnBack);
            RelocateCommand = new MyICommand(OnRelocate);
            ProfileCommand = new MyICommand(OnProfile);
        }

        public void OnLogOut()
        {
            ManagerHomePage.GetManagerHomePage().Content = new Login();
        }

        public void OnHomePage()
        {
            ManagerHomePage.GetManagerHomePage().Content = new ManagerHomePage();
        }

        public void OnProfile()
        {
            ManagerHomePage.GetManagerHomePage().Content = new ManagerProfile();
        }

        public void OnBack()
        {
            ManagerHomePage.GetManagerHomePage().Content = RoomsWindow.GetRoomsWindow();
        }

        public void OnRelocate()
        {
            if (SelectedEquipment == null)
            {
                new NotificationWindow("Select equipment you want to relocate!");
                return;
            }
            ManagerHomePage.GetManagerHomePage().Content = new EquipmentRelocation();
        }
    }
}
