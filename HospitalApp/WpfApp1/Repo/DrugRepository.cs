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
          foreach(Drug d in drugFileHandler.Read()) 
          {
               foreach(Drug dd in drugs) 
               {
                    if(d.Id == dd.Id) 
                    {
                        exists = true;
                        dd.Quantity += d.Quantity;
                        break;
                    } 
                
               }

                if (!exists) 
                {
                    drugs.Add(d);
                    exists = false;
                }

          }
          
          return drugs;
      }
      
      public bool Create(Drug drug)
      {
            List<Drug> drugs = drugFileHandler.Read();
            foreach(Drug d in drugs)
            {
                if(d.Name.ToLower() == drug.Name.ToLower())
                {
                    return false;
                }
            }
            drugs.Add(drug);
            drugFileHandler.Save(drugs);
            return true;
      }
      
      public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
   }
}