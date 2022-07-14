// File:    EquipmentRepository.cs
// Author:  smvul
// Created: Friday, April 15, 2022 7:52:54 PM
// Purpose: Definition of Class EquipmentRepository

using System;
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

        public void UpdateAll(List<Equipment> equipmentList)
        {
            List<Drug> drugs = new List<Drug>();
            List<Equipment> toDelete = new List<Equipment>();
            foreach (Equipment equipment in equipmentList) 
            {
                if (equipment.Type == EquipmentType.drug) 
                {
                    drugs.Add(MakeDrugFromEquipment(equipment));
                    toDelete.Add(equipment);
                }                
            }

            drugFileHandler.Save(drugs);
            equipmentFileHandler.Save(RemoveDrugsFromEquipmentList(equipmentList, toDelete));
        }


        public List<Equipment> SearchEquipment(string name, string room, string quantity)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(room) && !string.IsNullOrEmpty(quantity)){
                return GetByNameRoomAndQuantity(name, room, int.Parse(quantity));
            }
            else if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(room)){
                return GetByNameAndRoom(name, room);
            } else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(quantity))
            {
                return GetByNameAndQuantity(name, int.Parse(quantity));
            } else if (!string.IsNullOrEmpty(room) && !string.IsNullOrEmpty(quantity))
            {
                return GetByRoomAndQuantity(room, int.Parse(quantity));
            } else if (!string.IsNullOrEmpty(name)){
                return GetByName(name);
            } else if (!string.IsNullOrEmpty(room))
            {
                return GetByRoom(room);
            } else if (!string.IsNullOrEmpty(quantity))
            {
                return GetByQuantity(int.Parse(quantity));
            }
            else
            {
                return GetAll();
            }
            
        }


        private Drug MakeDrugFromEquipment(Equipment equipment)
        {
            foreach (Drug drug in drugFileHandler.Read())
            {
                if (drug.Id == equipment.Id)
                {
                    return new Drug(equipment.Id, equipment.Name, equipment.Quantity, equipment.Type, equipment.Room, drug.Manufacturer, drug.Ingredients, drug.Replacement, drug.Valid, drug.Reason);
                }
            }

            return null;
        }

        private List<Equipment> RemoveDrugsFromEquipmentList(List<Equipment> equipmentList, List<Equipment> toDelete)
        {
            for (int i = 0; i < toDelete.Count; i++)
            {
                equipmentList.Remove(toDelete[i]);
            }

            return equipmentList;
        }

        private List<Equipment> GetByQuantity(int quantity)
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

        private List<Equipment> GetByName(string name)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Name.ToLower().StartsWith(name.ToLower()))
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        private List<Equipment> GetByRoom(string roomId)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Room.Id.ToLower().StartsWith(roomId.ToLower()))
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        private List<Equipment> GetByNameAndRoom(string name, string roomId)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Room.Id.ToLower().Equals(roomId.ToLower()) && equipment.Name.ToLower().Equals(name.ToLower()))
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
                if (equipment.Quantity == quantity && equipment.Name.ToLower().Equals(name.ToLower()))
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        private List<Equipment> GetByRoomAndQuantity(string room, int quantity)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            {
                if (equipment.Quantity == quantity && equipment.Room.Id.ToLower().Equals(room.ToLower()))
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        private List<Equipment> GetByNameRoomAndQuantity(string name, string roomId, int quantity)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (Equipment equipment in GetAll())
            { 
                if (equipment.Name.ToLower().Equals(name.ToLower()) && equipment.Room.Id.ToLower().Equals(roomId.ToLower()) && equipment.Quantity == quantity)
                {
                    equipmentList.Add(equipment);
                }
            }

            return equipmentList;
        }

        public FileHandler.EquipmentFileHandler equipmentFileHandler = new FileHandler.EquipmentFileHandler();
        public FileHandler.DrugFileHandler drugFileHandler = new FileHandler.DrugFileHandler();
   
    }
}