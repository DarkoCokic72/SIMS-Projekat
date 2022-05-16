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
using WpfApp1.Model;

namespace WpfApp1.View.Patientt.Survey
{
    /// <summary>
    /// Interaction logic for QuestionnaireControl.xaml
    /// </summary>
    public partial class QuestionnaireControl : UserControl
    {
       
        public QuestionnaireControl()
        {
            InitializeComponent();
            Questions = new List<QuestionAndAnswers>();
            Answers = new ObservableCollection<Answer>();
            Answers.CollectionChanged += Answers_CollectionChanged;
        }

        private void Answers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var question in Questions)
            {
                question.Answers = new List<Answer>();
                foreach (var answer in Answers)
                {
                    question.Answers.Add(new Answer() { Text = answer.Text, Value = answer.Value, IsSelected = answer.IsSelected });
                }

            }

        }

        public List<QuestionAndAnswers> Questions
        {
            get { return (List<QuestionAndAnswers>)GetValue(QuestionsProperty); }
            set { SetValue(QuestionsProperty, value); }
        }

        public static readonly DependencyProperty QuestionsProperty =
            DependencyProperty.Register("Questions", typeof(List<QuestionAndAnswers>), typeof(QuestionnaireControl));

        public ObservableCollection<Answer> Answers
        {
            get { return (ObservableCollection<Answer>)GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }

        public static readonly DependencyProperty AnswersProperty =
            DependencyProperty.Register("Answers", typeof(ObservableCollection<Answer>), typeof(QuestionnaireControl), new FrameworkPropertyMetadata(null));

    }
}