using System.Windows.Controls;
using WpfApp1.ViewModel.Manager.Rooms;

namespace WpfApp1
{
    public partial class CreateRoom : UserControl
    {
        public CreateRoom()
        {
            InitializeComponent();
            DataContext = new CreateRoomViewModel();
        }

    }
}

