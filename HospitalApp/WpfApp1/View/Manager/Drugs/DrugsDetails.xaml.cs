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
using System.Windows.Shapes;

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsDetails.xaml
    /// </summary>
    public partial class DrugsDetails : Window
    {
        public DrugsDetails()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.Manual;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Top = 0.198*height;
            Left = 0.25*width;

            FillFields();
        }

        private void FillFields()
        {
            Ingredients.Text = DrugsWindow.SelectedDrug.Ingredients;
            Replacement.Text = DrugsWindow.SelectedDrug.Replacement;
            
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
