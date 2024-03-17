namespace GameDomain.Tokens
{
    public class Token
    {
        public int? TokenId { get; set; }
        public int? MapId { get; set; }
        public int? CharacterId { get; set; }
        public int? xPosition { get; set; }
        public int? yPosition { get; set; }
        public TokenImage? Image { get; set; }


        public Token UpdateToken(Token token) 
        {
            this.xPosition= token.xPosition;
            this.yPosition= token.yPosition;
            return this;
        }
    }

}
