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
            foreach(Drug drug in drugFileHandler.Read()) 
            {
                allEquipment.Add(new Equipment(drug.Id, drug.Name, drug.Quantity, drug.Type, drug.Room));
            }

            return allEquipment;
        }
      
        public List<Equipment> GetByRoomId(string roomId)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach(Equipment equipment in GetAll())
            {
                if(equipment.Room.Id == roomId)
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        private Drug MakeDrugFromEquipment(Equipment equipment) 
        {  
            foreach (Drug drug in drugFileHandler.Read())
            { 
                if (drug.Id == equipment.Id)
                {
                    return new Drug(equipment.Id, equipment.Name, equipment.Quantity, equipment.Type, equipment.Room, drug.Manufacturer, drug.Ingredients, drug.Replacement);    
                }
            }

            return null;    
        }

        private List<Equipment> RemoveDrugsFromEquipmentList(List<Equipment> equipmentList,List<Equipment> toDelete)
        {
            for (int i = 0; i < toDelete.Count; i++)
            {
                equipmentList.Remove(toDelete[i]);
            }

            return equipmentList;
        }

        public void UpdateAll(List<Equipment> equipmentList)
        {
            List<Drug> drugs = new List<Drug>();
            List<Equipment> toDelete = new List<Equipment>();
            foreach(Equipment equipment in equipmentList) 
            {
                if(equipment.Type == EquipmentType.drug) 
                {
                    drugs.Add(MakeDrugFromEquipment(equipment));
                    toDelete.Add(equipment);
                }                
            }

            drugFileHandler.Save(drugs);
            equipmentFileHandler.Save(RemoveDrugsFromEquipmentList(equipmentList, toDelete));
        }

        private List<Equipment> GetByQuantity (int quantity) 
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Quantity == quantity)
                {
                    equipmentList.Add(equipment);

                }
            }

            return equipmentList;
        }

        private List<Equipment> GetByName (string name) 
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Name.ToLower() == name.ToLower())
                {
                    equipmentList.Add(equipment);

                }
            }

            return equipmentList;
        }

        private List<Equipment> GetByNameAndQuantity(string name, int quantity) 
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Name.ToLower() == name.ToLower() && equipment.Quantity >= quantity)
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        public List<Equipment> SearchEquipment(string name, string quantity)
        {
           

            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(quantity))
            {
                return GetByQuantity(int.Parse(quantity));
            }

            if (string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(name)) 
            {
                return GetByName(name);
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(quantity))
            {
                return GetByNameAndQuantity(name, int.Parse(quantity));
            }
          
            return GetAll();         
        }
      
        public FileHandler.EquipmentFileHandler equipmentFileHandler = new FileHandler.EquipmentFileHandler();
        public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
    }
}