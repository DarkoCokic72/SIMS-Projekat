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
        public List<Survey> GetAllForHospital()
        {
            return surveysRepository.GetAllForHospital();
        }

        public double GetAverageGradeOfHospital()
        {
            double sum = 0;

            List<Answerr> allAnswers = new List<Answerr>();
            foreach (Survey surveys in surveysRepository.GetAllForHospital())
            {
                foreach (Question question in surveys.Question)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        allAnswers.Add(answer);
                    }
                }
            }

            foreach (Answerr answer in allAnswers)
            {
                sum += answer.Grade;
            }

            return Math.Round(sum/allAnswers.Count, 2);
        }

        public double GetAverageGradeOfHospitalCategory(string category)
        {
            double sum = 0;

            List<Answerr> allAnswers = new List<Answerr>();
            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                foreach (Answerr answer in question.Answer)
                {
                    allAnswers.Add(answer);
                }
            }


            foreach (Answerr answer in allAnswers)
            {
                sum += answer.Grade;
            }

            return Math.Round(sum/allAnswers.Count, 2);
        }

        public double GetAverageGradeOfHospitalCategoryQuestion(string category, string questionText)
        {
            double sum = 0;
            int count = 0;

            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                if (question.QuestionText == questionText)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        sum += answer.Grade;
                        count++;
                    }
                }
            }

            return Math.Round(sum/count, 2);
        }

        public List<GradeDTO> GetAllGradesOfHospitalCategoryQuestion(string category, string questionText)
        {
            List<GradeDTO> grades = new List<GradeDTO>();
            int count = 0;
            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                if (question.QuestionText == questionText)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        if (answer.Grade == 6)
                        {
                            count++;
                        }
                    }
                }
            }
            grades.Add(new GradeDTO(6, count));

            count = 0;
            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                if (question.QuestionText == questionText)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        if (answer.Grade == 7)
                        {
                            count++;
                        }
                    }
                }
            }
            grades.Add(new GradeDTO(7, count));

            count = 0;
            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                if (question.QuestionText == questionText)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        if (answer.Grade == 8)
                        {
                            count++;
                        }
                    }
                }
            }
            grades.Add(new GradeDTO(8, count));

            count = 0;
            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                if (question.QuestionText == questionText)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        if (answer.Grade == 9)
                        {
                            count++;
                        }
                    }
                }
            }
            grades.Add(new GradeDTO(9, count));

            count = 0;
            foreach (Question question in surveysRepository.GetByHospitalCategory(category).Question)
            {
                if (question.QuestionText == questionText)
                {
                    foreach (Answerr answer in question.Answer)
                    {
                        if (answer.Grade == 10)
                        {
                            count++;
                        }
                    }
                }
            }
            grades.Add(new GradeDTO(10, count));

            return grades;
        }

        public SurveysRepository surveysRepository = new SurveysRepository();
    }
}
