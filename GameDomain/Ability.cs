namespace GameDomain
{
    public class Ability
    {
        public int AbilityId { get; set; }
        public string Name { get; set;} = string.Empty;
        public string Description { get; set; } = string.Empty;
        public object Target { get; set; } = new object();
        public object Effect { get; set; } = new object();
        public int Range { get; set; }
        public int Duration { get; set; }
        public object Requirements { get; set; } = new object();
    }
}
