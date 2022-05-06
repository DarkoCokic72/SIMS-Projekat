// File:    AdvancedRenovationRepository.cs
// Author:  smvul
// Created: Friday, May 6, 2022 11:47:39 PM
// Purpose: Definition of Class AdvancedRenovationRepository

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
      
      public void Create(AdvancedRenovation renovation)
      {
            List<AdvancedRenovation> renovations = advancedRenovationFileHandler.Read();
            renovations.Add(renovation);
            advancedRenovationFileHandler.Write(renovations);
      }

        public FileHandler.AdvancedRenovationFileHandler advancedRenovationFileHandler = new FileHandler.AdvancedRenovationFileHandler();
   
   }
}