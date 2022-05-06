// File:    AdvancedRenovation.cs
// Author:  smvul
// Created: Friday, May 6, 2022 11:35:38 PM
// Purpose: Definition of Class AdvancedRenovation

using System;

namespace Model
{
   public class AdvancedRenovation
   {
      public System.Guid Id { get; set; }
      public RenovationType RenovationType { get; set; }
      public System.DateTime StartDate { get; set; }
      public int Duration { get; set; }
      public Room Room1 { get; set; }
      public Room Room2 { get; set; }
      public Room Room3 { get; set; }

      public AdvancedRenovation(RenovationType type, DateTime startDate, int duration, Room room1, Room room2, Room room3) 
      {
            Id = Guid.NewGuid();
            RenovationType = type;
            StartDate = startDate;
            Duration = duration;
            Room1 = room1;
            Room2 = room2;
            Room3 = room3;
        
      }
   
      
   }
}