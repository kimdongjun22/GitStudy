using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    public class Room
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Dictionary<string, Room> ConnectedRooms { get; private set; }
        public Puzzle Puzzle { get; set; }
        public bool IsPuzzleSolved { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            ConnectedRooms = new Dictionary<string, Room>();
        }

        public void Connect(string direction, Room room)
        {
            ConnectedRooms[direction] = room;
        }
    }
}
