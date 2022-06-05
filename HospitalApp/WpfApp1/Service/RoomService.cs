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
            List<DateTime> dates = patientExaminationAppointmentRepository.GetBusyDaysDueToAppointments(roomId); 
            dates.AddRange(renovationRepository.GetBusyDaysDueToRenovation(roomId));
            dates.AddRange(advancedRenovationRepository.GetBusyDaysDueToAdvancedRenovation(roomId));
            dates.Distinct();
            return dates;
        }

        public bool RoomIdExists(string roomId)
        {
            return roomRepository.RoomIdExists(roomId);
        }

        public RoomRepository roomRepository = new RoomRepository();
        public EquipmentService equipmentService = new EquipmentService();
        public ExaminationAppointmentRepository examinationAppointmentRepository = new ExaminationAppointmentRepository();
        public PatientExaminationAppointmentRepository patientExaminationAppointmentRepository = new PatientExaminationAppointmentRepository();
        public RenovationRepository renovationRepository = new RenovationRepository();
        public AdvancedRenovationRepository advancedRenovationRepository = new AdvancedRenovationRepository();
    
    }
}