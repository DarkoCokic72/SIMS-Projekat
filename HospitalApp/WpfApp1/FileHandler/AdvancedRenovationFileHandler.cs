// File:    AdvancedRenovationFileHandler.cs
// Author:  smvul
// Created: Friday, May 6, 2022 11:44:50 PM
// Purpose: Definition of Class AdvancedRenovationFileHandler

using System;
using System.Collections.Generic;
using Model;

namespace FileHandler
{
   public class AdvancedRenovationFileHandler
   {
      private string path = @"..\..\Data\AdvancedRenovationData.txt";

        public List<AdvancedRenovation> Read()
      {
            string renovationsSerialized = System.IO.File.ReadAllText(path);
            List<AdvancedRenovation> renovations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AdvancedRenovation>>(renovationsSerialized);
            return renovations;
        }
      
      public void Write(List<AdvancedRenovation> renovations)
      {
            string renovationSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(renovations);
            System.IO.File.WriteAllText(path, renovationSerialized);
        }
   
   }
}