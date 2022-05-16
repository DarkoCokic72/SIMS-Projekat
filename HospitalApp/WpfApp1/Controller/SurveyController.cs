//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WpfApp1.Service;
//using WpfApp1.Model;

//namespace WpfApp1.Controller
//{
//    public class SurveyController
//    {
//        public List<QuestionAndAnswers> GetAll()
//        {
//            return surveyService.GetAll();
//        }

//        public void Addd(QuestionAndAnswers appointments)
//        {
//            surveyService.Addd(appointments);
//        }

//        public void Delete(string id)
//        {
//            surveyService.Delete(id);
//        }

//        public void Update(QuestionAndAnswers appointments)
//        {
//            surveyService.Update(appointments);
//        }

//        public QuestionAndAnswers GetById(string id)
//        {
//            return surveyService.GetById(id);
//        }
//        public QuestionAndAnswers getAllFor(SurveyType type)
//        {
//            return surveyService.getAllFor(type);
//        }
//        public Service.SurveySevice surveyService = new SurveySevice();

//    }
//}
