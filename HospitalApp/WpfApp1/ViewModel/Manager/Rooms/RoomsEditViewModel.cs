using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
using WpfApp1.View;
using WpfApp1.View.Manager;

namespace WpfApp1.ViewModel.Manager.Rooms
{

    public class RoomsEditViewModel : BindableBase
    {
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
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private int selectedFloorBinding;
        public int SelectedFloorBinding
        {
            get
            {
                return selectedFloorBinding;
            }
            set
            {
                selectedFloorBinding = value;
                OnPropertyChanged("SelectedFloorBinding");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<int> FloorBinding { get; set; }

        private RoomType selectedTypeBinding;
        public RoomType SelectedTypeBinding
        {
            get
            {
                return selectedTypeBinding;
            }
            set
            {
                selectedTypeBinding = value;
                OnPropertyChanged("SelectedTypeBinding");
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<RoomType> RoomTypeBinding { get; set; }

        public RoomsEditViewModel()
        {
            UserBinding = Login.userAccount.Name + " " + Login.userAccount.Surname;
            RoomTypeBinding = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>());
            RoomTypeBinding.Remove(RoomType.Warehouse);
            selectedTypeBinding = RoomsWindowViewModel.SelectedRoom.Type;
            idBinding = RoomsWindowViewModel.SelectedRoom.Id;
            LoadFloors();
            CreateCommands();
        }


        private void LoadFloors()
        {
            FloorBinding = new ObservableCollection<int>
            {
                0,
                1,
                2,
                3
            };

            selectedFloorBinding = RoomsWindowViewModel.SelectedRoom.Floor;
        }

        private void CreateCommands()
        {
            SaveCommand = new MyICommand(OnSave, CanSave);
            CancelCommand = new MyICommand(OnCancel);
            HomePageCommand = new MyICommand(OnHomePage);
            LogOutCommand = new MyICommand(OnLogOut);
        }

        private void OnSave()
        {
            RoomsWindow.roomController.Update(new Room(IdBinding, SelectedTypeBinding, SelectedFloorBinding));
            ManagerHomePage.GetManagerHomePage().Content = RoomsWindow.GetRoomsWindow();  
        }

        private void OnCancel()
        {
            ManagerHomePage.GetManagerHomePage().Content = RoomsWindow.GetRoomsWindow();
        }

        private void OnLogOut()
        {
            ManagerHomePage.GetManagerHomePage().Content = new Login();
        }

        private void OnHomePage()
        {
            ManagerHomePage.GetManagerHomePage().Content = new ManagerHomePage();
        }

        private bool CanSave()
        {
             return true;
        }
    }
}

