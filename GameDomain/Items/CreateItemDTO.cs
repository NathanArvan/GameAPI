using GameDomain.Abilities;

namespace GameDomain.Items
{
    public class CreateItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public List<long>? AbilityIds { get; set; }
    }
}
