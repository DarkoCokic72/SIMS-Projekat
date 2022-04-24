/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  smvul
 * Purpose: Definition of the Class Repo.RoomRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Service;
using WpfApp1.Model;

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

        public void SchedulingRenovation(Renovation renovation)
        {
            roomService.SchedulingRenovation(renovation);
        }

        public List<System.DateTime> getBusyDates(string roomId)
        {
            return roomService.getBusyDates(roomId);
        }

        public Service.RoomService roomService = new RoomService();
       
    }
}