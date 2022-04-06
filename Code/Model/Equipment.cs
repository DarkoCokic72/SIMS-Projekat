/***********************************************************************
 * Module:  Equipment.cs
 * Author:  smvul
 * Purpose: Definition of the Class Model.Equipment
 ***********************************************************************/

using System;

namespace Model
{
   public class Equipment
   {
      private string id;
      private string name;
      
      public Room room;
      
      /// <summary>
      /// Property for Room
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Room Room
      {
         get
         {
            return room;
         }
         set
         {
            if (this.room == null || !this.room.Equals(value))
            {
               if (this.room != null)
               {
                  Room oldRoom = this.room;
                  this.room = null;
                  oldRoom.RemoveEquipment(this);
               }
               if (value != null)
               {
                  this.room = value;
                  this.room.AddEquipment(this);
               }
            }
         }
      }
   
   }
}