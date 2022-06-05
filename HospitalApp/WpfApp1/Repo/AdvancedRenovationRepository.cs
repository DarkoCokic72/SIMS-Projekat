using System;
using System.Collections.Generic;
using Model;

namespace Repo
{
    public class AdvancedRenovationRepository
    {
        public List<AdvancedRenovation> GetAll()
        {
            return advancedRenovationFileHandler.Read();
        }

        public List<AdvancedRenovation> GetByRoomId(string roomId)
        {
            List<AdvancedRenovation> renovations = new List<AdvancedRenovation>();
            foreach (AdvancedRenovation renovation in GetAll())
            {
                if (renovation.Room1.Id == roomId || renovation.Room2.Id == roomId || renovation.Room3.Id == roomId)
                {
                    renovations.Add(renovation);
                }
            }

            return renovations;
        }

        public void Create(AdvancedRenovation renovation)
        {
            List<AdvancedRenovation> renovations = advancedRenovationFileHandler.Read();
            renovations.Add(renovation);
            advancedRenovationFileHandler.Write(renovations);
        }

        public void Delete(AdvancedRenovation renovation) 
        {
            List<AdvancedRenovation> renovations = advancedRenovationFileHandler.Read();
            for (int i = 0; i < renovations.Count; i++)
            {
                if (renovations[i].Id == renovation.Id)
                {
                    renovations.RemoveAt(i);
                }
            }

            advancedRenovationFileHandler.Write(renovations);
        }

        public List<DateTime> GetBusyDaysDueToAdvancedRenovation(string roomId)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (AdvancedRenovation renovation in GetByRoomId(roomId))
            {
                days.Add(renovation.StartDate);
                days.AddRange(CalculateBusyDaysForAdvancedRenovationByDuration(renovation));
            }
            return days;
        }

        private List<DateTime> CalculateBusyDaysForAdvancedRenovationByDuration(AdvancedRenovation renovation)
        {
            List<DateTime> days = new List<DateTime>();
            for (int i = 1; i < renovation.Duration; i++)
            {
                days.Add(renovation.StartDate.AddDays(i));
            }
            return days;
        }

        public FileHandler.AdvancedRenovationFileHandler advancedRenovationFileHandler = new FileHandler.AdvancedRenovationFileHandler();
   
    }
}