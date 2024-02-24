namespace GameDomain
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal CarryingCapacity { get; set; }
        public List<Item> EquipedItems { get; set; } = new List<Item>();
        public List<Item> StoredItems { get; set; } = new List<Item>();
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
        public int StaminaPoints { get; set; }
        public int Poise { get; set; }
        public int Movement { get; set; }
        public int MartialVision { get; set; }
        public int ArcaneVision { get; set; }
        public int Actions { get; set; }
        public decimal Accuracy { get; set; }
        public decimal Evasion { get; set; }
    }
}
