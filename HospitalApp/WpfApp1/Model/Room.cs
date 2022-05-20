/***********************************************************************
 * Module:  Room.cs
 * Author:  smvul
 * Purpose: Definition of the Class Model.Room
 ***********************************************************************/

using System;
using Newtonsoft.Json.Linq;

namespace Model
{
   public class Room
   {
      public string Id { get; set; }
      public RoomType Type { get; set; }
      public int Floor { get; set; }

     public Room(string id, RoomType roomType, int floor)
     {
            this.Id = id;
            this.Type = roomType;
            this.Floor = floor;
     }

        public static explicit operator JToken(Room v)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            Room room = obj as Room;

            if (room == null) { return false; }

            return room.Id == Id;
        }
    }
}