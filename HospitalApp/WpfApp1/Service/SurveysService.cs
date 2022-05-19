using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Repo;

namespace WpfApp1.Service
{
    public class SurveysService
    {
        public List<Survey> GetAllForHospital()
        {
            return surveysRepository.GetAllForHospital();
        }

        public double GetAverageGradeOfHospital()
        {
            double sum = 0;

            List<Answerr> allAnswers = new List<Answerr>();
            foreach(Survey surveys in surveysRepository.GetAllForHospital())
            {
                foreach(Question question in surveys.Question)
                {
                    foreach(Answerr answer in question.Answer)
                    {
                        allAnswers.Add(answer);
                    }
                }
            }

            foreach(Answerr answer in allAnswers)
            {
                sum += answer.Grade;
            }

            return sum/allAnswers.Count;
        }

        public SurveysRepository surveysRepository = new SurveysRepository();
    }
}
