using GameDomain.Abilities;
using GameDomain.Characters;

namespace GameDomain.Items
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public List<Ability>? Abilities { get; set; }

        public List<Character>? Characters { get; set; }
    }
}
