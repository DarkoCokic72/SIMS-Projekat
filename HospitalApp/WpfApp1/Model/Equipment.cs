using System;
using Model;

namespace WpfApp1.Model
{
    public class Equipment
    {

            public string Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }

            public Room Room { get; set; }

            public Equipment(string id, string name, int quantity, Room room)
            {
                Id = id;
                Name = name;
                Quantity = quantity;
                Room = room;
            }    

    }
}