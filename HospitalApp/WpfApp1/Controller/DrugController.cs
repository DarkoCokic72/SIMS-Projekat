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

      public DrugService drugService = new DrugService();
   
   }
}