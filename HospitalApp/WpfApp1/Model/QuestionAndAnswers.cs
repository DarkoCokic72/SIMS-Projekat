using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class QuestionAndAnswers
    {
        public QuestionAndAnswers()
        {
            Answers = new List<Answer>();
        }
        public int Number { get; set; }
        public string Question { get; set; }
        public List<Answer> Answers { get; set; }
    }






}


