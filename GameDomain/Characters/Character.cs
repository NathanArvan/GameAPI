using GameDomain.Items;
using GameDomain.Tokens;
using GameDomain.Battles;
using System.ComponentModel.DataAnnotations.Schema;
using GameDomain.Users;
using GameDomain.Classes;

namespace GameDomain.Characters
{
    public class Character
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId { get; set; }
        public int? BattleId { get; set; }
        public Battle? Battle { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? ClassId { get; set; }
        public List<Class>? Classes { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? TokenId { get; set; }
        [NotMapped]

        public Token? Token { get; set; }
        public decimal CarryingCapacity { get; set; }
        public List<Item>? Items { get; set; } = new List<Item>();
        // public List<Item> StoredItems { get; set; } = new List<Item>();
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
        public int StaminaPoints { get; set; }
        public int Poise { get; set; }
        public int Movement { get; set; }
        public int MartialVision { get; set; }
        public int ArcaneVision { get; set; }
        public int Actions { get; set; }
        public int Accuracy { get; set; }
        public int Evasion { get; set; }
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public string image {  get; set; } = String.Empty;
    }
}
