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

        public List<Answerr> GetAnswers(string refersTo, string category, string questionText)
        {

            foreach(Question question in GetAllQuestions(refersTo, category))
            {
                if(question.QuestionText == questionText)
                {
                    return question.Answer;
                }
            }
            return null;
        }

        public List<Question> GetAllQuestions(string refersTo, string category)
        {
            foreach (Survey survey in GetAll(refersTo))
            {
                if (survey.Category == category)
                {
                    return survey.Question;
                }
            }
            return null;
        }

        public List<Answerr> GetAllAnswersForHospitalOrDoctor(string refersTo)
        {
            List<Answerr> allAnswers = new List<Answerr>();
            foreach (Survey surveys in GetAll(refersTo))
            {
                foreach (Question question in surveys.Question)
                {
                    allAnswers.AddRange(question.Answer);
                }
            }
            return allAnswers;
        }

        public List<Answerr> GetAllAnswersForCategory(string refersTo, string category)
        {
            List<Answerr> allAnswers = new List<Answerr>();
            foreach (Question question in GetAllQuestions(refersTo, category))
            {
                allAnswers.AddRange(question.Answer);
            }
            
            return allAnswers;
        }

        public SurveysFileHandler surveysFileHandler = new SurveysFileHandler();
    }
}
