// File:    EquipmentService.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 12:30:30 PM
// Purpose: Definition of Class EquipmentService

using System;
using System.Collections.Generic;
using Model;
using Repo;
using WpfApp1.Model;
using WpfApp1.View.Rooms;

namespace Service
{
    public class EquipmentService
    {
        public List<Equipment> GetAll()
        {
            return equipmentRepository.GetAll();
        }
      
        public List<Equipment> GetByRoomId(string roomId)
        {
            return equipmentRepository.GetByRoomId(roomId);
        }
      
        public void UpdateAll(List<Equipment> equipment)
        {
            equipmentRepository.UpdateAll(equipment);
        }

        public void Relocate()
        {
            foreach (Relocation relocation in relocationRepository.GetAll())
            {
                if (relocation.Date.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    List<Equipment> allEquipment = equipmentRepository.GetAll();
                    allEquipment = TakeEquipmentFromOldRoom(allEquipment, relocation);
                    allEquipment = MoveEquipmentToNewRoom(allEquipment, relocation);
                    equipmentRepository.UpdateAll(allEquipment);
                    relocationRepository.Delete(relocation);                
                } 
            }
        }
      
        public void CreateRelocationRequest(Relocation relocation)
        {
            relocationRepository.Create(relocation);
        }

        public int MaxQuantityToRelocate(Equipment equipment)
        {
            int quantity = equipment.Quantity;
            foreach (Relocation relocationRequest in relocationRepository.GetAll())
            {
                if (equipment.Id == relocationRequest.Equipment.Id && equipment.Room == relocationRequest.Equipment.Room)
                {
                    quantity -= relocationRequest.QuantityToRelocate;
                }
            }

            return quantity; 
        }

        public List<Equipment> SearchEquipment(string name, string room, string quantity) 
        {
            return equipmentRepository.SearchEquipment(name, room, quantity);
        }
      
        private List<Equipment> TakeEquipmentFromOldRoom(List<Equipment> allEquipment, Relocation relocation)
        {
            for (int i = 0; i < allEquipment.Count; i++)
            {
                if ((allEquipment[i].Room.Id == relocation.Equipment.Room.Id) && (allEquipment[i].Id == relocation.Equipment.Id))
                {
                    allEquipment[i].Quantity -= relocation.QuantityToRelocate;
                    if (allEquipment[i].Quantity == 0)
                    {
                        allEquipment.RemoveAt(i);
                    }
                    break;
                }
            }
            return allEquipment;
        }

        private List<Equipment> MoveEquipmentToNewRoom(List<Equipment> allEquipment, Relocation relocation)
        {
            bool equipmentInRoomExist = false;
            for (int i = 0; i < allEquipment.Count; i++)
            {
                if ((allEquipment[i].Room.Id == relocation.Room.Id) && (allEquipment[i].Id == relocation.Equipment.Id)) //equipment with that id alredy exist in room in which we want to relocate equipment
                {
                    allEquipment[i].Quantity += relocation.QuantityToRelocate;
                    equipmentInRoomExist = true;
                    break;
                }
            }

            if (!equipmentInRoomExist)
            {
                allEquipment.Add(new Equipment(relocation.Equipment.Id, relocation.Equipment.Name, relocation.QuantityToRelocate, relocation.Equipment.Type, relocation.Room));
            }
            return allEquipment;
        }

        public RelocationRepository relocationRepository = new RelocationRepository();
        public EquipmentRepository equipmentRepository = new EquipmentRepository();
   
    }
}