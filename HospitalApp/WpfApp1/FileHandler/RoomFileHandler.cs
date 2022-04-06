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

namespace FileHandler
{
    public class RoomFileHandler
   {

      public List<Room> Read()
      {
             string roomsSerialized = System.IO.File.ReadAllText(path); 
             List<Room> rooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Room>>(roomsSerialized);
             return rooms;
                  
        }
      
      public void Save(List<Room> rooms)
      {
            string roomsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(rooms);
            System.IO.File.WriteAllText(path, roomsSerialized);

      }
   
      private string path  = @"..\..\Data\RoomData.txt";
       
    }
}