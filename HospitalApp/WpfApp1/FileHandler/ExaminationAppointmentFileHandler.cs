using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace WpfApp1.FileHandler
{
    public class ExaminationAppointmentFileHandler
    {

        public List<ExaminationAppointment> Read()
        {
            //throw new NotImplementedException();

            string appointmentsSerialized = System.IO.File.ReadAllText(path);
            List<ExaminationAppointment> appointments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExaminationAppointment>>(appointmentsSerialized);
            return appointments;
        }

        public void Write(List<ExaminationAppointment> appointments)
        {
            //throw new NotImplementedException();

            string appointmentsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(appointments);
            System.IO.File.WriteAllText(path, appointmentsSerialized);
        }

        private string path = @"..\..\Data\AppointmentsData.txt";

    }
}
