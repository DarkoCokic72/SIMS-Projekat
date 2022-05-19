using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SurveysService surveysService = new SurveysService();
    }
}
