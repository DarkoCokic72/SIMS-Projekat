// File:    RenovationFileHandler.cs
// Author:  smvul
// Created: Saturday, April 23, 2022 11:35:04 PM
// Purpose: Definition of Class RenovationFileHandler

using System;
using System.Collections.Generic;
using WpfApp1.Model;

namespace FileHandler
{
   public class RenovationFileHandler
   {
      private string path = @"..\..\Data\RenovationData.txt";

      public List<Renovation> Read()
      {
            string renovationSerialized = System.IO.File.ReadAllText(path);
            List<Renovation> renovations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Renovation>>(renovationSerialized);
            return renovations;
        }
      
      public void Save(List<Renovation> renovations)
      {
           
            string renovationSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(renovations);
            System.IO.File.WriteAllText(path, renovationSerialized);
            
        }
   
   }
}