using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mirror
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        public List<Item> Inventory { get; private set; }

        public Player(Room startRoom)
        {
            CurrentRoom = startRoom;
            Inventory = new List<Item>();
        }

        public bool Move(string direction)
        {
            if (CurrentRoom.ConnectedRooms.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.ConnectedRooms[direction];
                return true;
            }
            return false;
        }

        public void ShowInventory()
        {
            Console.WriteLine("🎒 인벤토리:");
            if (Inventory.Count == 0)
                Console.WriteLine("- 없음");
            else
                foreach (var item in Inventory)
                    Console.WriteLine($"- {item.Name}: {item.Description}");
        }

        public bool HasItem(string itemName)
        {
            foreach (var item in Inventory)
            {
                if (item.Name == itemName)
                    return true;
            }
            return false;
        }
    }
}
