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
          bool exists = false;
          List<Drug> drugs = new List<Drug>();
          foreach (Drug drug in drugFileHandler.Read()) 
          {
               foreach (Drug dd in drugs) 
               {
                    if (drug.Id == dd.Id) 
                    {
                        exists = true;
                        dd.Quantity += drug.Quantity;
                        break;
                    } 
                
               }

                if (!exists) 
                {
                    drugs.Add(drug);
                    exists = false;
                }

          }
          
          return drugs;
      }
      
      public bool Create(Drug newDrug)
      {
            List<Drug> drugs = drugFileHandler.Read();
            foreach(Drug drug in drugs)
            {
                if(drug.Name.ToLower() == newDrug.Name.ToLower())
                {
                    return false;
                }
            }
            drugs.Add(newDrug);
            drugFileHandler.Save(drugs);
            return true;
      }
      
      public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
   }
}