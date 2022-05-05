﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Controller;
using Model;

namespace WpfApp1.View.Manager.Drugs
{
    /// <summary>
    /// Interaction logic for DrugsCreate.xaml
    /// </summary>
    public partial class DrugsCreate : Window
    {
        private int floorBinding;
        public int FloorBinding
        {
            get
            {
                return floorBinding;
            }
            set
            {
                floorBinding = value;
                OnPropertyChanged("FloorBinding");
            }
        }
        public DrugsCreate()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            SaveBtn.IsEnabled = false;
            Validation.StringToIntegerValidationRule.ValidationHasError = false;
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            ManagerHomePage managerHomePage = new ManagerHomePage();
            managerHomePage.Show();
            Close();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            DrugsWindow drugsWindow = new DrugsWindow();
            drugsWindow.Show();
            Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            DrugController drugController = new DrugController();
            RoomController roomController = new RoomController();
            drugController.Create(new Drug(Name.Text, int.Parse(Quantity.Text), roomController.GetById("R1"), Manufacturer.Text, Ingredients.Text, Replacement.Text));
            DrugsWindow drugsWindow = new DrugsWindow();
            drugsWindow.Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty(Manufacturer.Text) && !string.IsNullOrEmpty(Quantity.Text) && !string.IsNullOrEmpty(Ingredients.Text) &&
              !Validation.StringToIntegerValidationRule.ValidationHasError)
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
