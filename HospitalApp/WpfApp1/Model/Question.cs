using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<Answerr> Answer { get; set; }

        public Question(string questionText)
        {
            QuestionText = questionText;
            Answer = new List<Answerr>();
        }
    }
}
