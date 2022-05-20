using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Model;
using WpfApp1.Repo;

namespace WpfApp1.Service
{
    public class SurveysService
    {
        public List<Survey> GetAll(string refersTo)
        {
            return surveysRepository.GetAll(refersTo);
        }

        public double GetAverageGradeOfHospitalOrDoctor(string refersTo)
        {
            double sum = 0;
            int count = 0;
            foreach (Answerr answer in surveysRepository.GetAllAnswersForHospitalOrDoctor(refersTo))
            {
                sum += answer.Grade;
                count++;
            }

            return Math.Round(sum/count, 2);
        }

        public double GetAverageGradeOfCategory(string refersTo, string category)
        {
            double sum = 0;
            int count = 0;
            foreach (Answerr answer in surveysRepository.GetAllAnswersForCategory(refersTo, category))
            {
                sum += answer.Grade;
                count++;
            }

            return Math.Round(sum/count, 2);
        }

        public double GetAverageGradeOfQuestion(string refersTo, string category, string questionText)
        {
            double sum = 0;
            int count = 0;
            foreach (Answerr answer in surveysRepository.GetAnswers(refersTo, category, questionText))
            {
                sum += answer.Grade;
                count++; 
            }

            return Math.Round(sum/count, 2);
        }

        public List<GradeDTO> GetAllGradesOfQuestion(string refersTo ,string category, string questionText)
        {
            List<GradeDTO> grades = new List<GradeDTO>();
            for (int i = 6; i <= 10; i++) 
            {
                grades.Add(new GradeDTO(i, GetGradeCount(i, refersTo, category, questionText)));
            }

            return grades;
        }

        private int GetGradeCount(int grade, string refersTo, string category, string questionText)
        {
            int count = 0;
            foreach (Answerr answer in surveysRepository.GetAnswers(refersTo, category, questionText))
            {
                if (answer.Grade == grade)
                {
                    count++;
                }
            }
            return count;
        }

        public SurveysRepository surveysRepository = new SurveysRepository();
    }
}
