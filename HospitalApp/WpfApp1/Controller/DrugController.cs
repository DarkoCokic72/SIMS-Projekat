// File:    DrugController.cs
// Author:  smvul
// Created: Thursday, May 5, 2022 11:54:15 PM
// Purpose: Definition of Class DrugController

using System;
using System.Collections.Generic;
using Model;
using WpfApp1.Service;

namespace Controller
{
   public class DrugController
   {
      public List<Drug> GetAll()
      {
          return drugService.GetAll();  
      }
      
      public void Create(Drug drug)
      {
          drugService.Create(drug);
      }

      public bool Update(Drug drug)
      {
            return drugService.Update(drug);
      }

     public bool DrugExists(string drugName, string oldDrugName)
     {
         return drugService.DrugExists(drugName, oldDrugName);
     }
     public DrugService drugService = new DrugService();
   
   }
}