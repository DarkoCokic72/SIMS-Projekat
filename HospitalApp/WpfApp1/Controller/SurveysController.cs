using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Model;
using WpfApp1.Service;

namespace WpfApp1.Controller
{
    public class SurveysController
    {
        public List<Survey> GetAll(string refersTo)
        {
            return surveysService.GetAll(refersTo);
        }

        public double GetAverageGradeOfHospitalOrDoctor(string refersTo)
        {
            return surveysService.GetAverageGradeOfHospitalOrDoctor(refersTo);
        }

        public double GetAverageGradeOfCategory(string refersTo, string category)
        {
            return surveysService.GetAverageGradeOfCategory(refersTo, category);
        }

        public double GetAverageGradeOfQuestion(string refersTo, string category, string questionText)
        {
            return surveysService.GetAverageGradeOfQuestion(refersTo, category, questionText);
        }

        public List<GradeDTO> GetAllGradesOfQuestion(string refersTo, string category, string questionText)
        {
            return surveysService.GetAllGradesOfQuestion(refersTo, category, questionText);
        }
        public SurveysService surveysService = new SurveysService();
    }
}
