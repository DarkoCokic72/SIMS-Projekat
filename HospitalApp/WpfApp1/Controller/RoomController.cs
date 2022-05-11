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
      
        public bool Add(Room room)
        {
            return roomService.Add(room);
        }
      
        public bool Update(Room room)
        {
           return roomService.Update(room);
        }
      
        public void Remove(string id)
        {
            roomService.Remove(id);
        }

        public List<Equipment> getEquipment(string roomId)
        {
            return roomService.getEquipment(roomId);
        }

        public void SchedulingRenovation(Renovation renovation)
        {
            roomService.SchedulingRenovation(renovation);
        }

        public List<System.DateTime> GetBusyDates(string roomId)
        {
            return roomService.GetBusyDates(roomId);
        }

        public void SchedulingAdvancedRenovation(AdvancedRenovation renovation) 
        {
            roomService.SchedulingAdvancedRenovation(renovation);
        }

        public void Renovate() 
        {
            roomService.Renovate();
            
        }

        public bool RoomIdExists(string roomId) 
        {
            return roomService.RoomIdExists(roomId);
        }

        public Service.RoomService roomService = new RoomService();
       
    }
    }