namespace GameDomain
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<object> requirements { get; set; } = new List<object>();
    }
}
