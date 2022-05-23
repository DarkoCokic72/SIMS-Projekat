using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using WpfApp1.ViewModel.Manager.Drugs;

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsCreate.xaml
    /// </summary>
    public partial class DrugsCreate : UserControl
    {   
        public DrugsCreate()
        {
            InitializeComponent();
            this.DataContext = new DrugsCreateViewModel();
        }
    }
}
