/***********************************************************************
 * Module:  Room.cs
 * Author:  smvul
 * Purpose: Definition of the Class Model.Room
 ***********************************************************************/

using System;

namespace Model
{
   public class Room
   {
      public string Id { get; set; }
      public string Name { get; set; }
      public RoomType Type { get; set; }
      public int Floor { get; set; }

     public Room(string id, string name, RoomType roomType, int floor)
     {
            this.Id = id;
            this.Name = name;
            this.Type = roomType;
            this.Floor = floor;
     }
   
   }
}