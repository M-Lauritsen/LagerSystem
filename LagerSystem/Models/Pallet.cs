﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LagerSystem.Models
{
    public class Pallet
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public List<Item> Items { get; set; }
    }
}
