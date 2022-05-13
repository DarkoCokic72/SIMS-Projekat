﻿using System;
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
        public static DrugsDetails instance;
        public DrugsDetails()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.Manual;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Top = 0.198*height;
            Left = 0.25*width;

            Ingredients.Text = DrugsWindow.SelectedDrug.Ingredients;
            if (DrugsWindow.SelectedDrug.DrugB != null)
            {
                Replacement.Text = DrugsWindow.SelectedDrug.DrugB.Name;
            }
            Quantity.Text = DrugsWindow.SelectedDrug.Quantity.ToString();
        }

        public static DrugsDetails getInstance()
        {
            if (instance == null)
            {
                instance = new DrugsDetails();
            }

            return instance;
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            instance = null;
            Close();
        }
    }
}
