// File:    AdvancedRenovationFileHandler.cs
// Author:  smvul
// Created: Friday, May 6, 2022 11:44:50 PM
// Purpose: Definition of Class AdvancedRenovationFileHandler

using System;
using System.Collections.Generic;
using System.Threading;
using Model;

namespace FileHandler
{
   public class AdvancedRenovationFileHandler
   {
        private string path = @"..\..\Data\AdvancedRenovationData.txt";
        private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");

        public List<AdvancedRenovation> Read()
        {
            waitHandle.WaitOne();
            string renovationsSerialized = System.IO.File.ReadAllText(path);
            List<AdvancedRenovation> renovations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AdvancedRenovation>>(renovationsSerialized);
            waitHandle.Set();
            return renovations;
        }
      
      public void Write(List<AdvancedRenovation> renovations)
      {
            waitHandle.WaitOne();
            string renovationSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(renovations);
            System.IO.File.WriteAllText(path, renovationSerialized);
            waitHandle.Set();
        }
   
   }
}