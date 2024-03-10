namespace GameDomain.Tokens
{
    public class TokenImage
    {
        public int? TokenImageId { get; set; }
        public int? TokenId { get; set; }
        public byte[] Image { get; set; } = Array.Empty<byte>();
    }
}
