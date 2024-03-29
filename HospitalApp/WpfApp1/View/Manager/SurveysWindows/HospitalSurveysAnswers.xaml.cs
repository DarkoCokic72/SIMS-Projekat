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
using WpfApp1.DTO;

namespace WpfApp1.View.Manager.SurveysWindows
{
    /// <summary>
    /// Interaction logic for HospitalSurveysAnswers.xaml
    /// </summary>
    public partial class HospitalSurveysAnswers : UserControl
    {
        public double AverageGrade { get; set; }
        private readonly SurveysController surveysController = new SurveysController();
        public ObservableCollection<GradeDTO> Grades { get; set; }
        public HospitalSurveysAnswers()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Category.Content = "Question: " + HospitalSurveysQuestions.SelectedQuestion.QuestionText;
            AverageGrade = surveysController.GetAverageGradeOfQuestion("hospital", HospitalSurveysCategories.SelectedSurvey.Category, HospitalSurveysQuestions.SelectedQuestion.QuestionText);
            Grades = new ObservableCollection<GradeDTO>(surveysController.GetAllGradesOfQuestion("hospital", HospitalSurveysCategories.SelectedSurvey.Category, HospitalSurveysQuestions.SelectedQuestion.QuestionText));        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Content = new HospitalSurveysQuestions();
        }
    }
}
