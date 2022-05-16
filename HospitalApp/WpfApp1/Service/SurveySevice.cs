//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WpfApp1.Repo;
//using WpfApp1.Model;
//using Repo;

//namespace WpfApp1.Service
//{
//    public class SurveySevice
//    {
//        public SurveyRepository surveyRepository = new SurveyRepository();
//        public RoomRepository roomRepository = new RoomRepository();


//        public List<QuestionAndAnswers> GetAll()
//        {
//            return surveyRepository.GetAll();
//        }
//        public QuestionAndAnswers GetById(string id)
//        {
//            return surveyRepository.GetById(id);
//        }
//        public void Addd(QuestionAndAnswers surveys)
//        {
//            surveyRepository.Addd(surveys);
//        }

//        public void Delete(string Id)
//        {
//            surveyRepository.Delete(Id);
//        }

//        public void Update(QuestionAndAnswers surveys)
//        {
//            surveyRepository.Update(surveys);
//        }
//        public QuestionAndAnswers getAllFor(SurveyType type)
//        {
//            return surveyRepository.getAllFor(type);
//        }
//    }
//}
