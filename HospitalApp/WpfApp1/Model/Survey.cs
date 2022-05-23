using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Survey
    {
        public string RefersTo { get; set; }
        public string Category { get; set; }
        public List<Question> Question { get; set; }

        public Survey(string refersTo, string category)
        {
            RefersTo = refersTo;
            Category = category;
            Question = new List<Question>();
        }
    }
}
