/***********************************************************************
 * Module:  RoomFileHandler.cs
 * Author:  smvul
 * Purpose: Definition of the Class FileHandler.RoomFileHandler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using WpfApp1.Model;

namespace FileHandler
{
   public class EquipmentFileHandler
   {
        private string path = @"..\..\Data\EquipmentData.txt";
        private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        public List<Equipment> Read()
        {
            waitHandle.WaitOne();
            string equipmentSerialized = System.IO.File.ReadAllText(path);
            List<Equipment> equipment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Equipment>>(equipmentSerialized);
            waitHandle.Set();
            return equipment;
        }
      
        public void Save(List<Equipment> equipment)
        {
            waitHandle.WaitOne();
            string equipmentSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(equipment);
            System.IO.File.WriteAllText(path, equipmentSerialized);
            waitHandle.Set();
        }
   }
}