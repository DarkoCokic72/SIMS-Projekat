// File:    Drug.cs
// Author:  smvul
// Created: Thursday, May 5, 2022 11:39:40 PM
// Purpose: Definition of Class Drug

using System;
using Newtonsoft.Json;
using WpfApp1.Model;

namespace Model
{
    public class Drug : Equipment
    {
        public string Manufacturer { get; set; }
        public string Ingredients { get; set; }
        public Drug DrugB { get; set; }
        public bool Valid { get; set; }
        public string Reason {get; set; }

      public Drug(string name, int quantity, EquipmentType type, Room room, string manufacturer, string ingredients, Drug drugB, bool valid, string reason)
      {
            this.Id = System.Guid.NewGuid();
            this.Name = name;
            this.Quantity = quantity;
            this.Type = type;
            this.Room = room;
            this.Manufacturer = manufacturer;
            this.Ingredients = ingredients;
            this.DrugB = drugB;
            this.Valid = valid;
            this.Reason = reason;
      }

        [JsonConstructor]
        public Drug(Guid id, string name, int quantity, EquipmentType type, Room room, string manufacturer, string ingredients, Drug drugB)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Type = type;
            Room = room;
            Manufacturer = manufacturer;
            Ingredients = ingredients;
            DrugB = drugB;
        }
    }
}