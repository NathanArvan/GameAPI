using GameDomain.Abilities;
using GameDomain.Battles;
using GameDomain.Items;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameDomain.RuleSets
{
    public class RuleSet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RuleSetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
