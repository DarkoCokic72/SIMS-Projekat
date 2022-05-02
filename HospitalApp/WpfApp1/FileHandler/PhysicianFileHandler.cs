// File:    PhysicianFileHandler.cs
// Author:  HP LAPTOP
// Created: Friday, April 8, 2022 1:33:23 PM
// Purpose: Definition of Class PhysicianFileHandler

using System;
using Model;
using WpfApp1.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileHandler
{
   public class PhysicianFileHandler
   {
        private string path = @"..\..\Data\Physicians.txt";


      public List<Physician> Read()
      {
            //throw new NotImplementedException();
            if (!System.IO.File.Exists(path))
            {
                return new List<Physician>();
            }

            string physiciansSerialized = System.IO.File.ReadAllText(path);
            List<Physician> physicians = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Physician>>(physiciansSerialized);
            return physicians;
      }
      
      public void Write(List<Physician> physicians)
      {
            string physiciansSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(physicians);
            System.IO.File.WriteAllText(path, physiciansSerialized);
      }
   
   }
}