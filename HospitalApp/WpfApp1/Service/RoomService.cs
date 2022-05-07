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
            foreach (Room r in allRooms)
            {
                if (r.Type == RoomType.Warehouse)
                {
                    warehouseId = r.Id;
                }
            }
            List<Equipment> allEquipment = equipmentService.GetAll();
            bool inWarehouse = false;

            for (int i = 0; i < allEquipment.Count; i++)
            {
                if (allEquipment[i].Room.Id == roomId)
                {

                    for (int j = 0; j < allEquipment.Count; j++)
                    {
                        if (allEquipment[j].Room.Id == warehouseId)
                        {
                            if (allEquipment[i].Id == allEquipment[j].Id)
                            {
                                allEquipment[j].Quantity += allEquipment[i].Quantity;
                                allEquipment.RemoveAt(i);
                                inWarehouse = true;
                                break;
                            }
                        }
                    }

                    if (!inWarehouse)
                    {
                        allEquipment[i].Room.Id = warehouseId;
                        allEquipment[i].Room.Name = "Warehouse";
                        allEquipment[i].Room.Type = RoomType.Warehouse;
                    }

                    inWarehouse = false;
                }

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
                if (e.Room != null && e.Room.Id == roomId)
                {
                    dates.Add(e.DateOfAppointment);
                }

            }

            List<PatientExaminationAppointment> allPatientsAppointments = patientExaminationAppointmentRepository.GetAll();
            foreach (PatientExaminationAppointment e in allPatientsAppointments)
            {
                if (e.roomId == roomId)
                {
                    dates.Add(e.datetimeOfAppointment);
                }

            }


            List<Renovation> allRenovations = renovationRepository.GetAll();
            foreach (Renovation r in allRenovations)
            {
                if (r.Room.Id == roomId)
                {

                    dates.Add(r.StartDate);
                    for (int i = 1; i < r.Duration; i++)
                    {
                        dates.Add(r.StartDate.AddDays(i));
                    }

                }
            }

            dates.Distinct();

            return dates;


      }

      public void SchedulingAdvancedRenovation(AdvancedRenovation renovation) 
      {
            advancedRenovationRepository.Create(renovation);
      }

      public void Renovate() 
      {

            foreach (AdvancedRenovation r in advancedRenovationRepository.GetAll())
            {
                DateTime endDate = r.StartDate.AddDays(r.Duration - 1);
                DateTime currentDate = DateTime.Today;
                if (endDate.ToString("yyyy-MM-dd").Equals(currentDate.ToString("yyyy-MM-dd")))
                {

                   
                    if(r.RenovationType == RenovationType.merge) 
                    {
                        roomRepository.Remove(r.Room1.Id);
                        roomRepository.Remove(r.Room2.Id);
                        roomRepository.Add(r.Room3);
                        advancedRenovationRepository.Delete(r);
                        break;
                    }
                    if(r.RenovationType == RenovationType.split) 
                    {
                        
                       
                        roomRepository.Remove(r.Room1.Id);
                        roomRepository.Add(r.Room2);
                        roomRepository.Add(r.Room3);
                        advancedRenovationRepository.Delete(r);
                        break;
                    }

                }

            }


        }

      public Repo.RoomRepository roomRepository = new RoomRepository();
      public EquipmentService equipmentService = new EquipmentService();
      public ExaminationAppointmentRepository examinationAppointmentRepository = new ExaminationAppointmentRepository();
      public PatientExaminationAppointmentRepository patientExaminationAppointmentRepository = new PatientExaminationAppointmentRepository();
      public RenovationRepository renovationRepository = new RenovationRepository();
      public AdvancedRenovationRepository advancedRenovationRepository = new AdvancedRenovationRepository();
     

    }
}