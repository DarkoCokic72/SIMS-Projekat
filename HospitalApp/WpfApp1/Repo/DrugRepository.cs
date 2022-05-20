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
            if (DrugExists(newDrug, null)) return false;
            List<Drug> drugs = drugFileHandler.Read();
            drugs.Add(newDrug);
            drugFileHandler.Save(drugs);
            return true;
        }
      
        public bool Update(Drug newDrug, string oldNameOfDrug)
        {
            if (DrugExists(newDrug, oldNameOfDrug)) return false;
            List<Drug> drugs = GetAll();
            for (int i = 0; i < drugs.Count; i++)
            {
                if (drugs[i].Id == newDrug.Id)
                {
                    drugs[i].Name = newDrug.Name;
                    drugs[i].Manufacturer = newDrug.Manufacturer;
                    drugs[i].Ingredients = newDrug.Ingredients;
                    drugs[i].Replacement = newDrug.Replacement;
                    drugs[i].Valid = true;
                    drugs[i].Reason = null;
                    drugFileHandler.Save(drugs);
                }
            }
            return true;
        }
        private bool DrugExists(Drug newDrug, string oldNameOfDrug)
        {
            foreach (Drug drug in drugFileHandler.Read())
            {
                if (drug.Name.ToLower() == newDrug.Name.ToLower() && drug.Name.ToLower() != oldNameOfDrug.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

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


        public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
    }
}