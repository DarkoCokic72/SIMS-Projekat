// File:    EquipmentService.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 12:30:30 PM
// Purpose: Definition of Class EquipmentService

using System;
using System.Collections.Generic;
using Model;

namespace Service
{
   public class EquipmentService
   {
      public List<Equipment> GetAll()
      {
            return equipmentRepository.GetAll();
      }
      
      public List<Equipment> GetByRoomId(string roomId)
      {
            return equipmentRepository.GetByRoomId(roomId);
      }
      
      public void UpdateAll(List<Equipment> equipment)
      {
         equipmentRepository.UpdateAll(equipment);
      }
      
      public void Relocate()
      {
         throw new NotImplementedException(); //ovde thread
      }
      
      public void CreateRelocationRequest(Relocation relocation)
      {
            relocationRepository.Create(relocation);
      }
      
      public Repo.RelocationRepository relocationRepository = new Repo.RelocationRepository();
      public Repo.EquipmentRepository equipmentRepository = new Repo.EquipmentRepository();
   
   }
}