using System;
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
    /// Interaction logic for QuestionnaireControlAppointment.xaml
    /// </summary>
    public partial class QuestionnaireControlAppointment : UserControl
    {
        public QuestionnaireControlAppointment()
        {
            InitializeComponent();
            AppointmentQuestions = new List<QuestionAndAnswers>();
            Answers = new ObservableCollection<Answer>();
            Answers.CollectionChanged += Answers_CollectionChanged;
        }

        private void Answers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var question in AppointmentQuestions)
            {
                question.Answers = new List<Answer>();
                foreach (var answer in Answers)
                {
                    question.Answers.Add(new Answer() { Text = answer.Text, Value = answer.Value, IsSelected = answer.IsSelected });
                }

            }

        }

        public List<QuestionAndAnswers> AppointmentQuestions
        {
            get { return (List<QuestionAndAnswers>)GetValue(AppointmentQuestionsProperty); }
            set { SetValue(AppointmentQuestionsProperty, value); }
        }

        public static readonly DependencyProperty AppointmentQuestionsProperty =
            DependencyProperty.Register("AppointmentQuestions", typeof(List<QuestionAndAnswers>), typeof(QuestionnaireControlAppointment));

        public ObservableCollection<Answer> Answers
        {
            get { return (ObservableCollection<Answer>)GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }

        public static readonly DependencyProperty AnswersProperty =
            DependencyProperty.Register("Answers", typeof(ObservableCollection<Answer>), typeof(QuestionnaireControlAppointment), new FrameworkPropertyMetadata(null));

    }
}

