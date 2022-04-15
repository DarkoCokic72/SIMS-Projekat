/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  smvul
 * Purpose: Definition of the Class Repo.RoomRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
   public class RoomController
   {

      public List<Room> GetAll()
      {
         return roomService.GetAll();
      }
      
      public Room GetById(string id)
      {
         return roomService.GetById(id);
      }
      
      public void Add(Room room)
      {
            roomService.Add(room);
      }
      
      public void Update(Room room)
      {
            roomService.Update(room);
      }
      
      public void Remove(string id)
      {
            roomService.Remove(id);
            roomService.moveEquipmentToWarehouse(id);
      }

      public List<Equipment> getEquipment(string roomId)
        {
            return roomService.getEquipment(roomId);
        }

       public Service.RoomService roomService;
       
       public RoomController(RoomService roomService)
       {
            this.roomService = roomService;
       }

    }
}