// File:    Drug.cs
// Author:  smvul
// Created: Thursday, May 5, 2022 11:39:40 PM
// Purpose: Definition of Class Drug

using System;
using WpfApp1.Model;

namespace Model
{
   public class Drug : Equipment
   {
      public string Manufacturer { get; set; }
      public string Ingredients { get; set; }
      public string Replacement { get; set; }

      public Drug(string name, int quantity, Room room, string manufacturer, string ingredients, string replacement)
      {
            this.Id = System.Guid.NewGuid();
            this.Name = name;
            this.Quantity = quantity;
            this.Room = room;
            this.Manufacturer = manufacturer;
            this.Ingredients = ingredients;
            this.Replacement = replacement;
        
      }
    }
}