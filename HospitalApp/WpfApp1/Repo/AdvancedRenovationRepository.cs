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

        public FileHandler.AdvancedRenovationFileHandler advancedRenovationFileHandler = new FileHandler.AdvancedRenovationFileHandler();
   
    }
}