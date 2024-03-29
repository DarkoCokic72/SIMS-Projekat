// File:    EquipmentController.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 12:30:30 PM
// Purpose: Definition of Class EquipmentController

using System;
using System.Collections.Generic;
using Model;
using WpfApp1.Model;

namespace Controller
{
   public class EquipmentController
   {
      public List<Equipment> GetAll()
      {
            return equipmentService.GetAll();
      }
      public void Relocate()
      {
            equipmentService.Relocate();   
      }
      
      public void CreateRelocationRequest(Relocation relocation)
      {
            equipmentService.CreateRelocationRequest(relocation);
      }

      public int MaxQuantityToRelocate(Equipment equipment)
      {
            return equipmentService.MaxQuantityToRelocate(equipment);
      }
      
      public List<Equipment> SearchEquipment(string name, string room, string quantity) 
      {
            return equipmentService.SearchEquipment(name, room, quantity);
      }

      public Service.EquipmentService equipmentService = new Service.EquipmentService();
   
   }
}