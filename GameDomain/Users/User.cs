using GameDomain.Characters;

namespace GameDomain.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Character>? Characters { get; set; }
    }
}
