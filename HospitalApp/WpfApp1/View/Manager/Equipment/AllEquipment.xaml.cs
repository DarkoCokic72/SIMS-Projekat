﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Controller;

namespace WpfApp1.View.Manager.Equipment
{
    
    public partial class AllEquipment : UserControl
    {
        EquipmentController equipmentController = new EquipmentController();
        public ObservableCollection<Model.Equipment> Equipment { get; set; }
        public AllEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;

            Equipment = new ObservableCollection<Model.Equipment>(equipmentController.GetAll());
         
        }

        private void Button_Click_HomePage(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();      
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            dgEquipment.ItemsSource = null;
            dgEquipment.ItemsSource = new ObservableCollection<Model.Equipment>(equipmentController.SearchEquipment(Name.Text, Quantity.Text));
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
