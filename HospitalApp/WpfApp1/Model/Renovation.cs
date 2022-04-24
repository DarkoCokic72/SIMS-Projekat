using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Renovation
    {
        public System.Guid Id { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }

        public Renovation(string room, string description, System.DateTime startDate, System.DateTime endDate)
        {
            Id = System.Guid.NewGuid();
            this.Room = room;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

    }
}
