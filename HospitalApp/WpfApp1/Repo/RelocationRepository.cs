// File:    RelocationRepository.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 12:14:11 PM
// Purpose: Definition of Class RelocationRepository

using System;
using System.Collections.Generic;
using Model;
using WpfApp1;

namespace Repo
{
    public class RelocationRepository
    {
        public List<Relocation> GetAll()
        {
            return relocationFileHandler.Read();
        }
      
        public void Create(Relocation relocation)
        {
            List<Relocation> relocationList = relocationFileHandler.Read();
            relocationList.Add(relocation);
            relocationFileHandler.Save(relocationList);     
        }
      
        public void Delete(Relocation relocation)
        {
            List<Relocation> relocationList = relocationFileHandler.Read();
            for(int i = 0; i < relocationList.Count; i++)
            {
                if(relocationList[i].Id == relocation.Id)
                {
                    relocationList.RemoveAt(i);
                }
            }
           
            relocationFileHandler.Save(relocationList);
        }
      
        public FileHandler.RelocationFileHandler relocationFileHandler = new FileHandler.RelocationFileHandler();
   
    }
}