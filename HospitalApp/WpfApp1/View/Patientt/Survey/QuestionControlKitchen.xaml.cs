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
using WpfApp1.Model;

namespace WpfApp1.View.Patientt.Survey
{   /// <summary>
    /// Interaction logic for QuestionControlKitchen.xaml
    /// </summary>
    public partial class QuestionControlKitchen : UserControl
    {
        public QuestionControlKitchen()
        {
            InitializeComponent();
        }

        public List<QuestionAndAnswers> QuestionsKitchen
        {
            get { return (List<QuestionAndAnswers>)GetValue(QuestionsProperty); }
            set { SetValue(QuestionsProperty, value); }
        }

        public static readonly DependencyProperty QuestionsProperty =
            DependencyProperty.Register("QuestionsKitchen", typeof(List<QuestionAndAnswers>), typeof(QuestionControlKitchen),
                new PropertyMetadata(new List<QuestionAndAnswers>(), QuestionsChangedCallback));

        private static void QuestionsChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var q = o as QuestionControlKitchen;
            if (q == null)
                return;

            CopyAnswers(q);
        }

        public List<Answer> Answers
        {
            get { return (List<Answer>)GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }

        public static readonly DependencyProperty AnswersProperty =
                DependencyProperty.Register("Answers", typeof(List<Answer>), typeof(QuestionControlKitchen),
                    new PropertyMetadata(new List<Answer>(), AnswersChangedCallback));

        private static void AnswersChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var q = o as QuestionControlKitchen;
            if (q == null)
                return;

            CopyAnswers(q);
        }

        private static void CopyAnswers(QuestionControlKitchen q)
        {
            if (q.Answers == null || q.QuestionsKitchen == null)
                return;

            foreach (var question in q.QuestionsKitchen)
            {
                // remove old Answers
                question.Answers.Clear();
                // adding new Answers to each question
                foreach (var answer in q.Answers)
                    question.Answers.Add((Answer)answer.Clone());
            }
        }
    }
}

