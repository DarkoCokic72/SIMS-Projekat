/***********************************************************************
 * Module:  RoomFileHandler.cs
 * Author:  smvul
 * Purpose: Definition of the Class FileHandler.RoomFileHandler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace FileHandler
{
   public class EquipmentFileHandler
   {
      private string path = @"..\..\Data\EquipmentData.txt";

        public List<Equipment> Read()
      {
            string equipmentSerialized = System.IO.File.ReadAllText(path);
            List<Equipment> equipment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Equipment>>(equipmentSerialized);
            return equipment;
        }
      
      public void Save(List<Equipment> equipment)
      {
            string equipmentSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(equipment);
            System.IO.File.WriteAllText(path, equipmentSerialized);
      }
   
   }
}