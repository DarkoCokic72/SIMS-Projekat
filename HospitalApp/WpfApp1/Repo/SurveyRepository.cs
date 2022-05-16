//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WpfApp1.Model;
//using WpfApp1.FileHandler;

//namespace WpfApp1.Repo
//{
//    public class SurveyRepository
//    {
//        public SurveyFileHandler surveyFileHandler = new SurveyFileHandler();

//        public List<QuestionAndAnswers> GetAll()
//        {
//            return surveyFileHandler.Read();
//        }
//        public QuestionAndAnswers a;
//        public QuestionAndAnswers GetById(string id)
//        {

//            List<QuestionAndAnswers> list = GetAll();
//            foreach (QuestionAndAnswers a in list)
//            {

//                if (a.Id == id)
//                {
//                    return a;
//                }
//            }
//            return null;
//        }

//        public void Addd(QuestionAndAnswers survey)
//        {
//            if (GetById(survey.Id) == null)
//            {
//                List<QuestionAndAnswers> list = GetAll();
//                list.Add(survey);
//                surveyFileHandler.Write(list);
//            }
      
//        }

//        public void Delete(string id)
//        {
//            List<QuestionAndAnswers> list = GetAll();
//            for (int i = 0; i < list.Count; i++)
//            {

//                if (list[i].Id == id)
//                {
//                    list.Remove(list[i]);
//                }
//            }

//                surveyFileHandler.Write(list);
//        }


//        public void Update(QuestionAndAnswers appointments)
//        {
//            List<QuestionAndAnswers> list = GetAll();
//            //if (Appointments.AppointmentsInstance.getSelectedAppointments().id != appointments.id)
//            //{
//            //    for (int i = 0; i < list.Count; i++)
//            //    {
//            //        if (list[i].id.Equals(appointments.id))
//            //        {
//            //            EditAppointment.editedAppointment = false;
//            //            return;
//            //        }
//            //    }
//            //}

//            //for (int i = 0; i < list.Count; i++)
//            //{

//            //    if (list[i].id.Equals(HospitalSurvey.HospitalSurveyInstance.getSelectedHospitalSurvey().id))
//            //    {

//            //        list[i] = appointments;
//            //        patientAppointmentFileHandler.Write(list);
//            //       // EditAppointment.editedAppointment = true;
//            //    }


//        }

//        public QuestionAndAnswers getAllFor(SurveyType type)
//        {
//            return surveyFileHandler.LoadFor(type);
//        }

//    }
//}

