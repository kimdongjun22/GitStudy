using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        public List<Item> Inventory { get; private set; }

        public Player()
        {
            Inventory = new List<Item>();
        }
    }
}
