using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
    public class GradeDTO
    {
       
        public GradeDTO(int grade, int count)
        {
            Grade = grade;
            Count = count;
        }

        public int Grade { get; set; }
        public int Count { get; set; }
    }
}
