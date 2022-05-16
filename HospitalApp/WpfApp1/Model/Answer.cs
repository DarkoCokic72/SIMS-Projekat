using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Answer : ICloneable
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public bool IsSelected { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
