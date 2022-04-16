// File:    EquipmentController.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 12:30:30 PM
// Purpose: Definition of Class EquipmentController

using System;
using Model;

namespace Controller
{
   public class EquipmentController
   {
      public void Relocate()
      {
            equipmentService.Relocate();   
      }
      
      public void CreateRelocationRequest(Relocation relocation)
      {
            equipmentService.CreateRelocationRequest(relocation);
      }
      
      public Service.EquipmentService equipmentService = new Service.EquipmentService();
   
   }
}