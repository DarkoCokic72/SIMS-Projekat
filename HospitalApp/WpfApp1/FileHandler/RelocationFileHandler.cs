// File:    RelocationFileHandler.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 11:43:44 AM
// Purpose: Definition of Class RelocationFileHandler

using System;
using System.Collections.Generic;
using Model;

namespace FileHandler
{
   public class RelocationFileHandler
   {
      private string path = @"..\..\Data\RelocationData.txt";
      
      public List<Relocation> Read()
      {
            string relocationSerialized = System.IO.File.ReadAllText(path);
            List<Relocation> relocation = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Relocation>>(relocationSerialized);
            return relocation;
        }
      
      public void Save(List<Relocation> relocation)
      {
            string relocationSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(relocation);
            System.IO.File.WriteAllText(path, relocationSerialized);
        }
   
   }
}