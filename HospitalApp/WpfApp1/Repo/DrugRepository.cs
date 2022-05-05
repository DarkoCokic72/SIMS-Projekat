// File:    DrugRepository.cs
// Author:  smvul
// Created: Thursday, May 5, 2022 11:47:52 PM
// Purpose: Definition of Class DrugRepository

using System;
using System.Collections.Generic;
using Model;

namespace Repo
{
   public class DrugRepository
   {
      public List<Drug> GetAll()
      {
          return drugFileHandler.Read();
      }
      
      public void Create(Drug drug)
      {
            List<Drug> drugs = drugFileHandler.Read();
            drugs.Add(drug);
            drugFileHandler.Save(drugs);
      }
      
      public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
   }
}