// File:    RelocationFileHandler.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 11:43:44 AM
// Purpose: Definition of Class RelocationFileHandler

using System;
using System.Collections.Generic;
using System.Threading;
using Model;

namespace FileHandler
{
   public class RelocationFileHandler
   {
      private string path = @"..\..\Data\RelocationData.txt";
      private EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        public List<Relocation> Read()
        {
            waitHandle.WaitOne();
            string relocationSerialized = System.IO.File.ReadAllText(path);
            List<Relocation> relocation = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Relocation>>(relocationSerialized);
            waitHandle.Set();
            return relocation;
        }
      
      public void Save(List<Relocation> relocation)
      {
            waitHandle.WaitOne();
            string relocationSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(relocation);
            System.IO.File.WriteAllText(path, relocationSerialized);
            waitHandle.Set();
        }
   
   }
}