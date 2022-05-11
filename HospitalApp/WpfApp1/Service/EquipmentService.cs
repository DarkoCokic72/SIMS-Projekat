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
            while (true)
            {
                bool equipmentInRoomExists = false;
                System.DateTime currentDate = DateTime.Now;
                
                foreach (Relocation r in relocationRepository.GetAll())
                {
                    if (r.Date.ToString("yyyy-MM-dd").Equals(currentDate.ToString("yyyy-MM-dd")))
                    {
                        List<Equipment> allEquipment = equipmentRepository.GetAll();
                        //first take equipment from room
                        for (int i = 0; i < allEquipment.Count; i++)
                        {
                            if ((allEquipment[i].Room.Id == r.Equipment.Room.Id) && (allEquipment[i].Id == r.Equipment.Id))
                            {
                               
                                allEquipment[i].Quantity -= r.QuantityToRelocate;
                                if (allEquipment[i].Quantity == 0)
                                {
                                    allEquipment.RemoveAt(i);
                                }

                                break;

                            }

                        }

                       

                        //now we put equipment in new room
                        for (int i = 0; i < allEquipment.Count; i++)
                        {
                       
                            if ((allEquipment[i].Room.Id == r.Room.Id) && (allEquipment[i].Id == r.Equipment.Id)) //equipment with that id alredy exist in room in which we want to relocate equipment
                            {
                                
                                allEquipment[i].Quantity += r.QuantityToRelocate;
                                equipmentInRoomExists = true;
                                break;

                            }

                        }

                        if (!equipmentInRoomExists)
                        {
                            allEquipment.Add(new Equipment(r.Equipment.Id, r.Equipment.Name, r.QuantityToRelocate, r.Equipment.Type, r.Room));
                        }


                        equipmentInRoomExists = false;
                        equipmentRepository.UpdateAll(allEquipment);
                        relocationRepository.Delete(r);
                        break;
                        
                    }

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
                if(equipment.Id == relocationRequest.Equipment.Id && equipment.Room == relocationRequest.Equipment.Room)
                {
                    quantity -= relocationRequest.QuantityToRelocate;
                }
            }

            return quantity; 
      }

      public List<Equipment> SearchEquipment(string name, string quantity) 
      {
            return equipmentRepository.SearchEquipment(name, quantity);
      }
      
      public RelocationRepository relocationRepository = new RelocationRepository();
      public EquipmentRepository equipmentRepository = new EquipmentRepository();
   
   }
}