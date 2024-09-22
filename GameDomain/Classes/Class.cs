using GameDomain.Characters;

namespace GameDomain.Classes
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; } = string.Empty;

        public int? CharacterId { get; set; }

        public List<Character>? Characters { get; set; }
    }
}
