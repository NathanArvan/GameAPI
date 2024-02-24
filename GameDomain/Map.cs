namespace GameDomain
{
    public class Map
    {
        public int MapId { get; set; }
        public int CampaignId { get; set; }
        public string Image { get; set; } = string.Empty;
        public int Length { get; set; }
        public int Width { get; set; }
    }
}
