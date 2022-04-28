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
using WpfApp1.View.Secretary;

namespace WpfApp1.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryHomePage.xaml
    /// </summary>
    public partial class SecretaryHomePage : Window
    {
        public SecretaryHomePage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Patients"))
            {
                PatientsWindow patientsWindow = PatientsWindow.GetPatientsWindow();
                patientsWindow.Show();

            }

        }
    }
}