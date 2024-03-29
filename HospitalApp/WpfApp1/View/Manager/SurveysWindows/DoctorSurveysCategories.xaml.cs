﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Controller;
using WpfApp1.Model;

namespace WpfApp1.View.Manager.SurveysWindows
{
    public partial class DoctorSurveysCategories : UserControl
    {
        public ObservableCollection<Survey> Surveys { get; set; }
        public double AverageGrade { get; set; }
        public static Survey SelectedSurvey { get; set; }
        public SurveysController surveysController = new SurveysController();
        public DoctorSurveysCategories()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Category.Content = "Doctor: " + ChooseDoctor.SelectedDoctor.Name + " " + ChooseDoctor.SelectedDoctor.Surname;
            AverageGrade = surveysController.GetAverageGradeOfHospitalOrDoctor(ChooseDoctor.SelectedDoctor.UniquePersonalNumber);
            Surveys = new ObservableCollection<Survey>(surveysController.GetAll(ChooseDoctor.SelectedDoctor.UniquePersonalNumber));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Questions(object sender, RoutedEventArgs e)
        {
            this.Content = new DoctorSurveysQuestions();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
            ChooseDoctor chooseDoctor = new ChooseDoctor();
            chooseDoctor.ShowDialog();
        }
    }
}
