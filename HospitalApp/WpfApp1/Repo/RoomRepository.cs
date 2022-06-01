
/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  smvul
 * Purpose: Definition of the Class Repo.RoomRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using FileHandler;
using Model;

namespace Repo
{
   public class RoomRepository
   {
        public List<Room> GetAll()
        {
            return roomFileHandler.Read();
        }
      
        public Room GetById(string id)
        {
            foreach (Room room in GetAll())
            { 
                if (room.Id == id) return room;
            }
            return null;
        }

        public Room GetWarehouse() 
        {
            foreach (Room room in GetAll())
            {
                if (room.Type == RoomType.Warehouse) return room;
            }

            return null;
        }
      
        public void Add(Room room)
        {
            List<Room> listOfRooms = GetAll();
            listOfRooms.Add(room);
            roomFileHandler.Save(listOfRooms);
        }
      
        public bool Update(Room room)
        {
            List<Room> listOfRooms = GetAll();
            for (int i = 0; i < listOfRooms.Count; i++)
            { 
                if (listOfRooms[i].Id == room.Id)
                {
                    listOfRooms[i] = room;
                    roomFileHandler.Save(listOfRooms);
                    return true;
                }
            }
            return false;
        }
      
      public void Remove(string id)
      {
            List<Room> listOfRooms = GetAll();
            for (int i = 0; i < listOfRooms.Count; i++)
            {
                if (listOfRooms[i].Id == id)
                {
                    listOfRooms.Remove(listOfRooms[i]);

                }
            }
          
            roomFileHandler.Save(listOfRooms);
      }

        public bool RoomIdExists(string roomId)
        {
            foreach (Room room in GetAll())
            {
                if (room.Id == roomId) return true; 
            }
            return false;
        }

        public RoomFileHandler roomFileHandler = new RoomFileHandler();
   }
}