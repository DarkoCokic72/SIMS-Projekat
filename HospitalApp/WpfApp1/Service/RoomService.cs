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

        public bool Update(Room room)
        {
            return roomRepository.Update(room);
        }

        public void Remove(string id)
        {
            roomRepository.Remove(id);
        }

        public List<Equipment> GetEquipment(string roomId)
        {
            return equipmentService.GetByRoomId(roomId);
        }

        public List<DateTime> GetBusyDates(string roomId)
        {
            List<DateTime> dates = GetBusyDaysDueToAppointments(roomId); 
            dates.AddRange(GetBusyDaysDueToRenovation(roomId));
            dates.AddRange(GetBusyDaysDueToAdvancedRenovation(roomId));
            dates.Distinct();
            return dates;
        }

        public bool RoomIdExists(string roomId)
        {
            return roomRepository.RoomIdExists(roomId);
        }

        private List<DateTime> GetBusyDaysDueToRenovation(string roomId)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (Renovation renovation in renovationRepository.GetByRoomId(roomId))
            {
                days.Add(renovation.StartDate);
                days.AddRange(CalculateBusyDaysForRenovationByDuration(renovation));
            }
            return days;
        }

        private List<DateTime> CalculateBusyDaysForRenovationByDuration(Renovation renovation)
        {
            List<DateTime> days = new List<DateTime>();
            for (int i = 1; i < renovation.Duration; i++)
            {
                days.Add(renovation.StartDate.AddDays(i));
            }
            return days;
        }

        private List<DateTime> GetBusyDaysDueToAdvancedRenovation(string roomId)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (AdvancedRenovation renovation in advancedRenovationRepository.GetByRoomId(roomId))
            {
                days.Add(renovation.StartDate);
                days.AddRange(CalculateBusyDaysForAdvancedRenovationByDuration(renovation));
            }
            return days;
        }

        private List<DateTime> CalculateBusyDaysForAdvancedRenovationByDuration(AdvancedRenovation renovation)
        {
            List<DateTime> days = new List<DateTime>();
            for (int i = 1; i < renovation.Duration; i++)
            {
                days.Add(renovation.StartDate.AddDays(i));
            }
            return days;
        }


        private List<DateTime> GetBusyDaysDueToAppointments(string roomId)
        {
            List<DateTime> days = new List<DateTime>();
            foreach (PatientExaminationAppointment appointment in patientExaminationAppointmentRepository.GetAll())
            {
                if (appointment.roomId == roomId)
                {
                    days.Add(appointment.datetimeOfAppointment);
                }
            }
            return days;
        }

        public RoomRepository roomRepository = new RoomRepository();
        public EquipmentService equipmentService = new EquipmentService();
        public ExaminationAppointmentRepository examinationAppointmentRepository = new ExaminationAppointmentRepository();
        public PatientExaminationAppointmentRepository patientExaminationAppointmentRepository = new PatientExaminationAppointmentRepository();
        public RenovationRepository renovationRepository = new RenovationRepository();
        public AdvancedRenovationRepository advancedRenovationRepository = new AdvancedRenovationRepository();
    
    }
}