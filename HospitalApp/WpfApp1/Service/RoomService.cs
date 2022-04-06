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

      public Repo.RoomRepository roomRepository;

      public RoomService(RoomRepository roomRepository)
      {

            this.roomRepository = roomRepository;

      }

   }
}