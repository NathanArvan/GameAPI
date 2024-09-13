using GameDomain.Items;
using GameDomain.RuleSets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameDomain.Abilities
{
    public class Ability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbilityId { get; set; }
        public int RuleSetId { get; set; }
        public RuleSet? RuleSet { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [NotMapped]
        public object? Target { get; set; } = new object();
        [NotMapped]
        public object? Effect { get; set; } = new object();
        public int Range { get; set; }
        public int Duration { get; set; }
        [NotMapped]
        public object Requirements { get; set; } = new object();
        public List<Item>? Items { get; set; }
    }
}
