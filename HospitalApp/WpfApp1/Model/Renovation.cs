using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace WpfApp1.Model
{
    public class Renovation
    {
        public System.Guid Id { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public Room Room { get; set; }

        public Renovation(Room room, string description, System.DateTime startDate, int duration)
        {
            Id = System.Guid.NewGuid();
            this.Room = room;
            this.Description = description;
            this.StartDate = startDate;
            this.Duration = duration;
        }

    }
}
