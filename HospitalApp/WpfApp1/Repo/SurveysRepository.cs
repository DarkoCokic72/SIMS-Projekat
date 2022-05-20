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
        public List<Survey> GetAll(string refersTo)
        {
            List<Survey> hospitalSurveys = new List<Survey>();
            foreach (Survey survey in surveysFileHandler.Read())
            {
                if (survey.RefersTo.ToLower() == refersTo.ToLower())
                {
                    hospitalSurveys.Add(survey);
                }
            }
            return hospitalSurveys;
        }

        public Survey GetQuestionsByCategory(string refersTo, string category)
        {
            
            foreach(Survey survey in GetAll(refersTo))
            {
                if(survey.Category == category)
                {
                    return survey;
                }
            }
            return null;
        }

        public SurveysFileHandler surveysFileHandler = new SurveysFileHandler();
    }
}
