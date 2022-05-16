//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WpfApp1.Model;

//namespace WpfApp1.FileHandler
//{
//   public class SurveyFileHandler
//    {
//        private string path = @"..\..\Data\SurveyData.txt";

//        public List<QuestionAndAnswers> Read()
//        {
//            if (!System.IO.File.Exists(path))
//            {
//                return new List<QuestionAndAnswers>();
//            }
//            string questionAndAnswersSerialized = System.IO.File.ReadAllText(path);
//            List<QuestionAndAnswers> surveys = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionAndAnswers>>(questionAndAnswersSerialized);
//            return surveys;
//        }

//        public void Write(List<QuestionAndAnswers> appointments)
//        {

//            string patientExaminationAppointmentSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(appointments);
//            System.IO.File.WriteAllText(path, patientExaminationAppointmentSerialized);
//        }
//        public QuestionAndAnswers LoadFor(SurveyType type)
//        {
//            return Read().LastOrDefault(questionAndAnswers => questionAndAnswers.Type == type);
//        }
//    }
//}
