﻿using GameDomain.Abilities;
using GameDomain.Characters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameDomain.Items
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public List<Ability>? Abilities { get; set; }

        public List<Character>? Characters { get; set; }
    }
}
