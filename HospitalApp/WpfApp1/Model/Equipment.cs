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

        public Equipment(string id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
        

    }
}