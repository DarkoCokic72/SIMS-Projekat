// File:    PhysicianFileHandler.cs
// Author:  HP LAPTOP
// Created: Friday, April 8, 2022 1:33:23 PM
// Purpose: Definition of Class PhysicianFileHandler

using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.FileHandler
{
    public class PhysicianFileHandler
    {

        public List<Physician> Read()
        {

            if (!System.IO.File.Exists(path))
            {
                return new List<Physician>();
            }

            string physicianSerialized = System.IO.File.ReadAllText(path);
            List<Physician> physician = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Physician>>(physicianSerialized);
            return physician;
        }

        public void Save(List<Physician> physician)
        {
            string physicianSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(physician);
            System.IO.File.WriteAllText(path, physicianSerialized);
        }

        private string path = @"..\..\Data\Physicians.txt";
    }
}