using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.FileHandler
{
    public class SurveysFileHandler
    {
        string path = @"..\..\Data\SurveysData.txt";
        public List<Survey> Read()
        {
            string surveysSerialized = System.IO.File.ReadAllText(path);
            List<Survey> surveys = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Survey>>(surveysSerialized);
            return surveys;
        }

        public void Save(List<Survey> surveys)
        {
            string surveysSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(surveys);
            System.IO.File.WriteAllText(path, surveysSerialized);
        }
    }
}
