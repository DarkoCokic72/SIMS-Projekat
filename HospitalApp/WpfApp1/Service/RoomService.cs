/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  smvul
 * Purpose: Definition of the Class Repo.RoomRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Repo;
using WpfApp1.Model;

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
            return equipmentService.GetByRoomId(roomId);
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
            List<Equipment> allEquipment = equipmentService.GetAll();
            bool inWarehouse = false;
            List<int> toRemove = new List<int>();

            for (int i = 0; i < allEquipment.Count; i++)
            {
                if(allEquipment[i].Room == roomId)
                {

                    for(int j = 0; j < allEquipment.Count; j++)
                    {
                        if (allEquipment[j].Room == warehouseId)
                        {
                            if (allEquipment[i].Id == allEquipment[j].Id)
                            {
                                allEquipment[j].Quantity += allEquipment[i].Quantity;
                                toRemove.Add(i);
                                inWarehouse = true;
                                break;
                            }
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

            equipmentService.UpdateAll(allEquipment);
      }

      public void SchedulingRenovation(Renovation renovation)
      {
            renovationRepository.Create(renovation);
      }

      public List<System.DateTime> getBusyDates(string roomId)
      {
            List<System.DateTime> dates = new List<DateTime>();
            List<ExaminationAppointment> allAppointments = examinationAppointmentRepository.GetAll();

            foreach (ExaminationAppointment e in allAppointments)
            {
                if (e.Room == roomId)
                {
                    dates.Add(e.DateOfAppointment);
                }

            }

            List<Renovation> allRenovations = renovationRepository.GetAll();

            foreach(Renovation r in allRenovations) 
            {
                if(r.Room == roomId) 
                {
                    
                    dates.Add(r.StartDate);
                    for(int i=1; i < r.Duration; i++)
                    {
                        dates.Add(r.StartDate.AddDays(i));
                    }
                   

                }
            }

            dates.Distinct();

            return dates;

      }

      public Repo.RoomRepository roomRepository = new RoomRepository();
      public EquipmentService equipmentService = new EquipmentService();
      public RenovationRepository renovationRepository = new RenovationRepository();
      public ExaminationAppointmentRepository examinationAppointmentRepository = new ExaminationAppointmentRepository(new WpfApp1.FileHandler.ExaminationAppointmentFileHandler());

    }
}