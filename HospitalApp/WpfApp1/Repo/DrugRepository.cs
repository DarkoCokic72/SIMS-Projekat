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
      
        public bool IsDrugAlreadyInList(List<Drug> drugs, Drug drugToAdd) 
        {     
            foreach (Drug drug in drugs) 
            {
                if (drug.Id == drugToAdd.Id)
                {
                    drug.Quantity += drugToAdd.Quantity;
                    return true;
                }
            }

            return false;
        }

        public List<Drug> GetAll()
        {
          
            List<Drug> drugs = new List<Drug>();
            foreach (Drug drug in drugFileHandler.Read()) 
            {
                if (!IsDrugAlreadyInList(drugs, drug))
                {
                    drugs.Add(drug);

                }        
            }
            return drugs;
        }
      
        public bool Create(Drug newDrug)
        {
            if (DrugExists(newDrug)) return false;
            List<Drug> drugs = drugFileHandler.Read();
            drugs.Add(newDrug);
            drugFileHandler.Save(drugs);
            return true;
        }
      
        private bool DrugExists(Drug newDrug)
        {
            foreach (Drug drug in drugFileHandler.Read())
            {
                if (drug.Name.ToLower() == newDrug.Name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }


        public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
    }
}