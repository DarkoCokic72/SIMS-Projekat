using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace WpfApp1.Repo
{
    public class SurveysRepository
    {
        public List<Survey> GetAllForHospital()
        {
            List<Survey> hospitalSurveys = new List<Survey>();
            foreach (Survey survey in surveysFileHandler.Read())
            {
                if (survey.RefersTo.ToLower() == "Hospital".ToLower())
                {
                    hospitalSurveys.Add(survey);
                }
            }
            return hospitalSurveys;
        }

        public SurveysFileHandler surveysFileHandler = new SurveysFileHandler();
    }
}
