// File:    EquipmentRepository.cs
// Author:  smvul
// Created: Friday, April 15, 2022 7:52:54 PM
// Purpose: Definition of Class EquipmentRepository

using System;
using System.Collections.Generic;
using Model;

namespace Repo
{
   public class EquipmentRepository
   {
      public List<Equipment> GetAll()
      {
            return equipmentFileHandler.Read();
      }
      
      public List<Equipment> GetByRoomId(string roomId)
      {
            List<Equipment> allEquipment = equipmentFileHandler.Read();
            List<Equipment> equipment = new List<Equipment>();

            foreach(Equipment e in allEquipment)
            {
                if(e.Room == roomId)
                {
                    equipment.Add(e);
                }
            }

            return equipment;
      }
      
      public FileHandler.EquipmentFileHandler equipmentFileHandler = new FileHandler.EquipmentFileHandler();
   
   }
}