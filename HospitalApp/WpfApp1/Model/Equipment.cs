using System;
using Model;

namespace WpfApp1.Model
{
    public class Equipment
    {

            public System.Guid Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }

            public Room Room { get; set; }

            public Equipment(System.Guid id, string name, int quantity, Room room)
            {
                Id = id;
                Name = name;
                Quantity = quantity;
                Room = room;
            }   
            
            public Equipment() { }

    }
}