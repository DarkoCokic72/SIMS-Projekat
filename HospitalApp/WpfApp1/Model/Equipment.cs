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
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string Room { get; set; }

        public Equipment(string id, string name, int quantity, string room)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Room = room;
        }
        

    }
}