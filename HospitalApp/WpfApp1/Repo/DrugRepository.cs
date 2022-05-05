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
         throw new NotImplementedException();
      }
      
      public void Create(Drug drug)
      {
         throw new NotImplementedException();
      }
      
      public FileHandler.DrugFileHandler drugFileHandler;
   
   }
}