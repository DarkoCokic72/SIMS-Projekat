using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Repo
{
    public class RenovationRepository
    {
        public List<Renovation> GetAll()
        {
            return renovationFileHandler.Read();
        }

        public List<Renovation> GetByRoomId(string roomId) 
        {
            List<Renovation> renovations = new List<Renovation>(); 
            foreach (Renovation renovation in GetAll())
            {
                if (renovation.Room.Id == roomId)
                {
                    renovations.Add(renovation);
                }
            }

            return renovations;
        }

        public void Create(Renovation renovation)
        {
            List<Renovation> renovationList = renovationFileHandler.Read();
            renovationList.Add(renovation);
            renovationFileHandler.Save(renovationList);
        }

        public List<DateTime> GetBusyDaysDueToRenovation(string roomId)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (Renovation renovation in GetByRoomId(roomId))
            {
                days.Add(renovation.StartDate);
                days.AddRange(CalculateBusyDaysForRenovationByDuration(renovation));
            }
            return days;
        }

        private List<DateTime> CalculateBusyDaysForRenovationByDuration(Renovation renovation)
        {
            List<DateTime> days = new List<DateTime>();
            for (int i = 1; i < renovation.Duration; i++)
            {
                days.Add(renovation.StartDate.AddDays(i));
            }
            return days;
        }

        public FileHandler.RenovationFileHandler renovationFileHandler = new FileHandler.RenovationFileHandler();

    }
}
