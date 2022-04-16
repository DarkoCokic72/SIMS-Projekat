// File:    EquipmentService.cs
// Author:  smvul
// Created: Saturday, April 16, 2022 12:30:30 PM
// Purpose: Definition of Class EquipmentService

using System;
using System.Collections.Generic;
using Model;
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
                System.DateTime currentDate = DateTime.Now;
                List<Equipment> allEquipment = equipmentRepository.GetAll();
                foreach (Relocation r in relocationRepository.GetAll())
                {
                    if (r.Date.ToString("yyyy-MM-dd").Equals(currentDate.ToString("yyyy-MM-dd")))
                    {
                        //first take equipment from room
                        for (int i = 0; i < allEquipment.Count; i++)
                        {
                            if (allEquipment[i].Room == r.Equipment.Room && allEquipment[i].Id == r.Equipment.Id)
                            {

                                allEquipment[i].Quantity -= r.QuantityToRelocate;
                                if (allEquipment[i].Quantity == 0)
                                {
                                    allEquipment.RemoveAt(i);

                                }

                            }

                        }

                        //now we put equipment in new room
                        bool equipmentInRoomExists = false;
                        for (int i = 0; i < allEquipment.Count; i++)
                        {
                            if (allEquipment[i].Room == r.ToRoom && allEquipment[i].Id == r.Equipment.Id) //equipment with that id alredy exist in room in which we want to relocate equipment
                            {

                                allEquipment[i].Quantity += r.QuantityToRelocate;
                                equipmentInRoomExists = true;

                            }

                        }

                        if (!equipmentInRoomExists)
                        {
                            allEquipment.Add(new Equipment(r.Equipment.Id, r.Equipment.Name, r.QuantityToRelocate, r.ToRoom));
                        }


                        relocationRepository.Delete(r);
                        equipmentRepository.UpdateAll(allEquipment);

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
            int retVal = equipment.Quantity;

            foreach(Relocation r in relocationRepository.GetAll())
            {
                if(equipment.Id == r.Equipment.Id && equipment.Room == r.Equipment.Room)
                {
                    retVal -= r.QuantityToRelocate;
                }
            }

            return retVal; 
      }
      
      public Repo.RelocationRepository relocationRepository = new Repo.RelocationRepository();
      public Repo.EquipmentRepository equipmentRepository = new Repo.EquipmentRepository();
   
   }
}