/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  smvul
 * Purpose: Definition of the Class Repo.RoomRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repo;

namespace Service
{
   public class RoomService
   {

      public List<Room> GetAll()
      {
         return roomRepository.GetAll();
      }
      
      public Room GetById(string id)
      {
         return roomRepository.GetById(id);
      }
      
      public void Add(Room room)
      {
            roomRepository.Add(room);
      }
      
      public void Update(Room room)
      {
            roomRepository.Update(room);
      }
      
      public void Remove(string id)
      {
            roomRepository.Remove(id);
      }

      public List<Equipment> getEquipment(string roomId)
      {
            return equipmentRepository.GetByRoomId(roomId);
      }

      public void moveEquipmentToWarehouse(string roomId)
      {
            string warehouseId = null;
            List<Room> allRooms = roomRepository.GetAll();
            foreach(Room r in allRooms)
            {
                if(r.Type == RoomType.Warehouse)
                {
                    warehouseId = r.Id;
                }
            }
            List<Equipment> allEquipment = equipmentRepository.GetAll();
            bool inWarehouse = false;
            List<int> toRemove = new List<int>();

            for (int i=0; i<allEquipment.Count; i++)
            {
                if(allEquipment[i].Room == roomId)
                {

                    for(int j=0; j<allEquipment.Count; j++)
                    {
                        if (allEquipment[i].Id == allEquipment[j].Id && allEquipment[j].Room == warehouseId)
                        {
                            allEquipment[j].Quantity += allEquipment[i].Quantity;
                            inWarehouse = true;
                        }
                    }

                    if(!inWarehouse)
                    {
                        allEquipment[i].Room = warehouseId;
                    }

                    inWarehouse = false;
                }

            }

            for(int i=0; i < toRemove.Count; i++)
            {
                allEquipment.RemoveAt(toRemove[i]);
            }

            equipmentRepository.Set(allEquipment);
      }

      public Repo.RoomRepository roomRepository;
      public Repo.EquipmentRepository equipmentRepository = new EquipmentRepository();

      public RoomService(RoomRepository roomRepository)
      {

            this.roomRepository = roomRepository;

      }

   }
}