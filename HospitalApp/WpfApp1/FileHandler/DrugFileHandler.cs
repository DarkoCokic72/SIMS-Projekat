// File:    DrugFileHandler.cs
// Author:  smvul
// Created: Thursday, May 5, 2022 11:46:13 PM
// Purpose: Definition of Class DrugFileHandler

using System;
using System.Collections.Generic;
using System.Threading;
using Model;

namespace FileHandler
{
   public class DrugFileHandler
   {
      string path = @"..\..\Data\DrugsData.txt";
      private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
      public List<Drug> Read()
      {
            waitHandle.WaitOne();
            string drugsSerialized = System.IO.File.ReadAllText(path);
            List<Drug> drugs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Drug>>(drugsSerialized);
            waitHandle.Set();
            return drugs;
        }
      
      public void Save(List<Drug> drugs)
      {
            waitHandle.WaitOne();
            string drugsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(drugs);
            System.IO.File.WriteAllText(path, drugsSerialized);
            waitHandle.Set();
        }
   
   }
}