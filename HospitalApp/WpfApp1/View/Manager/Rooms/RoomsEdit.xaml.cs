using System.Windows.Controls;
using WpfApp1.ViewModel.Manager.Rooms;

namespace WpfApp1
{
 
    public partial class RoomsEdit : UserControl
    {
        public RoomsEdit()
        {
            InitializeComponent();
            this.DataContext = new RoomsEditViewModel();
        }
    }
}
    



