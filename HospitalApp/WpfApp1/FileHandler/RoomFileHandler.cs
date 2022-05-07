/***********************************************************************
 * Module:  RoomFileHandler.cs
 * Author:  smvul
 * Purpose: Definition of the Class FileHandler.RoomFileHandler
 ***********************************************************************/

using System.Collections.Generic;
using Model;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileHandler
{
    public class RoomFileHandler
   {

      public List<Room> Read()
      {
             waitHandle.WaitOne();
             string roomsSerialized = System.IO.File.ReadAllText(path); 
             List<Room> rooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Room>>(roomsSerialized);
             waitHandle.Set();
             return rooms;
                  
        }
      
      public void Save(List<Room> rooms)
      {
            waitHandle.WaitOne();
            string roomsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(rooms);
            System.IO.File.WriteAllText(path, roomsSerialized);
            waitHandle.Set();
      }
   
      private string path  = @"..\..\Data\RoomData.txt";
      private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");

    }
}