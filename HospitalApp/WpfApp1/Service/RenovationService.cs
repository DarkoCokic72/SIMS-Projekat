using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repo;
using Service;
using WpfApp1.Model;

namespace WpfApp1.Service
{
    public class RenovationService
    {
        public void SchedulingRenovation(Renovation renovation)
        {
            renovationRepository.Create(renovation);
        }

        public void Renovate()
        {
            foreach (AdvancedRenovation advancedRenovationRequest in advancedRenovationRepository.GetAll())
            {
                if (IsRenovationFinished(advancedRenovationRequest.StartDate.AddDays(advancedRenovationRequest.Duration - 1)))
                {
                    RenovateAccordingToRenovationType(advancedRenovationRequest);
                }
            }
        }

        public void SchedulingAdvancedRenovation(AdvancedRenovation renovation)
        {
            advancedRenovationRepository.Create(renovation);
            if (renovation.RenovationType == RenovationType.merge)
            {
                MoveEquipmentToWarehouseWhenMergeStarts(renovation);

            }
            else
            {
                MoveEquipmentToWarehouseWhenSplitStarts(renovation);
            }
        }

        private bool IsRenovationFinished(DateTime endDate)
        {
            DateTime currentDate = DateTime.Today;
            return endDate.ToString("yyyy-MM-dd").Equals(currentDate.ToString("yyyy-MM-dd"));
        }


        private void RenovateAccordingToRenovationType(AdvancedRenovation advancedRenovationRequest)
        {
            if (advancedRenovationRequest.RenovationType == RenovationType.merge)
            {
                MergeRooms(advancedRenovationRequest);
            }
            else
            {
                SplitRoom(advancedRenovationRequest);
            }
        }

        private void MergeRooms(AdvancedRenovation advancedRenovationRequest)
        {
            roomRepository.Remove(advancedRenovationRequest.Room1.Id);
            roomRepository.Remove(advancedRenovationRequest.Room2.Id);
            roomRepository.Add(advancedRenovationRequest.Room3);
            advancedRenovationRepository.Delete(advancedRenovationRequest);
        }

        private void SplitRoom(AdvancedRenovation advancedRenovationRequest)
        {
            roomRepository.Remove(advancedRenovationRequest.Room1.Id);
            roomRepository.Add(advancedRenovationRequest.Room2);
            roomRepository.Add(advancedRenovationRequest.Room3);
            advancedRenovationRepository.Delete(advancedRenovationRequest);
        }

        private void MoveEquipmentToWarehouseWhenMergeStarts(AdvancedRenovation renovation)
        {
            foreach (Equipment equipment in equipmentService.GetByRoomId(renovation.Room1.Id))
            {
                equipmentService.CreateRelocationRequest(new Relocation(renovation.StartDate, equipment.Quantity, roomRepository.GetById("R1"), equipment));
            }

            foreach (Equipment equipment in equipmentService.GetByRoomId(renovation.Room2.Id))
            {
                equipmentService.CreateRelocationRequest(new Relocation(renovation.StartDate, equipment.Quantity, roomRepository.GetById("R1"), equipment));
            }
        }

        private void MoveEquipmentToWarehouseWhenSplitStarts(AdvancedRenovation renovation)
        {
            foreach (Equipment equipment in equipmentService.GetByRoomId(renovation.Room1.Id))
            {
                equipmentService.CreateRelocationRequest(new Relocation(renovation.StartDate, equipment.Quantity, roomRepository.GetById("R1"), equipment));
            }
        }

        public RoomRepository roomRepository = new RoomRepository();
        public EquipmentService equipmentService = new EquipmentService();
        public RenovationRepository renovationRepository = new RenovationRepository();
        public AdvancedRenovationRepository advancedRenovationRepository = new AdvancedRenovationRepository();
    }
}
