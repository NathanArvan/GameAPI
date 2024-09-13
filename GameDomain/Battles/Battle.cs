using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GameDomain.Characters;
using GameDomain.Items;
using GameDomain.RuleSets;
namespace GameDomain.Battles
{
    public class Battle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? BattleId { get; set; }
        public int RuleSetId { get; set; }
        public RuleSet? RuleSet { get; set; }
        public int? Turn {  get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();
     }
}
