﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name + " - " + Description;
        }
    }

}
