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
        public List<Survey> GetAllForHospital()
        {
            return surveysService.GetAllForHospital();
        }

        public double GetAverageGradeOfHospital()
        {
            return surveysService.GetAverageGradeOfHospital();
        }

        public double GetAverageGradeOfHospitalCategory(string category)
        {
            return surveysService.GetAverageGradeOfHospitalCategory(category);
        }

        public double GetAverageGradeOfHospitalCategoryQuestion(string category, string questionText)
        {
            return surveysService.GetAverageGradeOfHospitalCategoryQuestion(category, questionText);
        }

        public List<GradeDTO> GetAllGradesOfHospitalCategoryQuestion(string category, string questionText)
        {
            return surveysService.GetAllGradesOfHospitalCategoryQuestion(category, questionText);
        }
        public SurveysService surveysService = new SurveysService();
    }
}
