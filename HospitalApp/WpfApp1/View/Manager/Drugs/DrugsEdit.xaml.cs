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
using WpfApp1.ViewModel.Manager.Drugs;

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsEdit.xaml
    /// </summary>
    public partial class DrugsEdit : UserControl
    {
        public DrugsEdit()
        {
            InitializeComponent();
            this.DataContext = new DrugsEditViewModel();
        }
    }
}
