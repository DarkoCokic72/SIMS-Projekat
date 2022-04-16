// File:    Relocation.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 11:45:20 AM
// Purpose: Definition of Class Relocation

using System;

namespace Model
{
   public class Relocation
   {
      public System.DateTime Date { get; set; }
      public int QuantityToRelocate { get; set; }
      public string ToRoom { get; set; }

      public Equipment Equipment { get; set; }

      public Relocation(System.DateTime date, int quantityToRelocate, string toRoom, Equipment equipment)
      {
            Date = date;
            QuantityToRelocate = quantityToRelocate;
            ToRoom = toRoom;
            Equipment = equipment;
      }
   
   }
}