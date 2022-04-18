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
            List<Equipment> equipmentByRooms = equipmentFileHandler.Read();
            List<Equipment> allEquipment = new List<Equipment>();
            bool exists = false;

            foreach (Equipment e1 in equipmentByRooms)
            {
                exists = false;
                foreach(Equipment e2 in allEquipment)
                {
                    if(e1.Id == e2.Id)
                    {
                        e2.Quantity += e1.Quantity;
                        exists = true;
                    }
                }

                if (!exists)
                {
                    allEquipment.Add(e1);
                }
            }


            return allEquipment;
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

      public void UpdateAll(List<Equipment> equipment)
      {
            equipmentFileHandler.Save(equipment);
      }
      
      public FileHandler.EquipmentFileHandler equipmentFileHandler = new FileHandler.EquipmentFileHandler();
   
   }
}