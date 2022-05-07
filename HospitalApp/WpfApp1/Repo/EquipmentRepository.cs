// File:    EquipmentRepository.cs
// Author:  smvul
// Created: Friday, April 15, 2022 7:52:54 PM
// Purpose: Definition of Class EquipmentRepository

using System.Collections.Generic;
using Model;
using WpfApp1.Model;

namespace Repo
{
    public class EquipmentRepository
   {
      public List<Equipment> GetAll()
      {
            List<Equipment> allEquipment = equipmentFileHandler.Read();
            List<Drug> drugs = drugFileHandler.Read();
            foreach(Drug d in drugs) 
            {
                allEquipment.Add(new Equipment(d.Id, d.Name, d.Quantity, d.Type, d.Room));
            
            }

            return allEquipment;
      }
      
      public List<Equipment> GetByRoomId(string roomId)
      {
            List<Equipment> allEquipment = equipmentFileHandler.Read();
            List<Drug> drugs = drugFileHandler.Read();
            foreach (Drug d in drugs)
            {
                allEquipment.Add(new Equipment(d.Id, d.Name, d.Quantity, d.Type, d.Room));

            }

            List<Equipment> equipment = new List<Equipment>();
            foreach(Equipment e in allEquipment)
            {
                if(e.Room.Id == roomId)
                {
                    equipment.Add(e);
                }
            }

            return equipment;
      }

      public void UpdateAll(List<Equipment> equipment)
      {
            List<Drug> drugs = new List<Drug>();
            List<Equipment> toDelete = new List<Equipment>();
            foreach(Equipment e in equipment) 
            {
               
                if(e.Type == EquipmentType.drug) 
                {
                    Drug drug = null;
                    foreach (Drug d in drugFileHandler.Read())
                    {
                    
                        if (d.Id == e.Id)
                        { 
                            drug = new Drug(e.Id, e.Name, e.Quantity, e.Type, e.Room, d.Manufacturer, d.Ingredients, d.Replacement);
                            toDelete.Add(e);
                            break;
                        }
                    }

                    drugs.Add(drug);
                }
                            
            }

            for (int i=0; i < toDelete.Count; i++) 
            {
                equipment.Remove(toDelete[i]);
            }

     
            drugFileHandler.Save(drugs);
            equipmentFileHandler.Save(equipment);
      }

      public List<Equipment> SearchEquipment(string name, string quantity) 
      {
            List<Equipment> equipment = new List<Equipment>();
            List<Equipment> allEquipment = GetAll();

            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(quantity))
            {
                int quantity2 = int.Parse(quantity);
                foreach (Equipment e in allEquipment)
                {
                    if (e.Quantity == quantity2)
                    {
                        equipment.Add(e);

                    }
                }
            }


            if (string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(name)) 
            {
                foreach (Equipment e in allEquipment)
                {
                    if (e.Name == name)
                    {
                        equipment.Add(e);

                    }
                }
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(quantity))
            {
                int quantity2 = int.Parse(quantity);
                foreach (Equipment e in allEquipment)
                {
                    if (e.Name == name && e.Quantity >= quantity2)
                    {
                        equipment.Add(e);

                    }
                }
            }

            if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(quantity)) 
            {
                equipment = allEquipment;  
            }

            return equipment;  
      }
      
      public FileHandler.EquipmentFileHandler equipmentFileHandler = new FileHandler.EquipmentFileHandler();
      public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
   }
}