
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
         // TODO: implement
         return roomFileHandler.Read();
      }
      
      public Room GetById(string id)
      {
         List<Room> listOfRooms = GetAll();
         foreach (Room r in listOfRooms)
         { 
            if(r.Id == id)
                {

                    return r;

                }   
            
         }

         return null;
      }
      
      public void Add(Room room)
      {
            if (GetById(room.Id) == null) {

                List<Room> listOfRooms = GetAll();
                listOfRooms.Add(room);
                roomFileHandler.Save(listOfRooms);
                WpfApp1.CreateRoom.addedRoom = true;
            }
            else 
            {

                WpfApp1.CreateRoom.addedRoom = false;

            }
      }
      
      public void Update(Room room)
      {
            List<Room> listOfRooms = GetAll();
   

            for (int i = 0; i < listOfRooms.Count; i++)
            {
                
                if (listOfRooms[i].Id == room.Id)
                {

                    listOfRooms[i] = room;
                    roomFileHandler.Save(listOfRooms);
                    WpfApp1.RoomsEdit.editedRoom = true;

                }
            }

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

       public FileHandler.RoomFileHandler roomFileHandler;

       public RoomRepository(RoomFileHandler fileHandler)
       {
            roomFileHandler = fileHandler;
       }


    }
}