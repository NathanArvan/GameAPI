namespace GameDomain.Tokens
{
    public interface ITokenRepository
    {
        public Task<List<Token>> GetTokens();

        public Task<Token> InsertToken(Token token);

        public Task<TokenImage> InsertTokenImage(TokenImage image);

        public Task<List<Token>> GetTokensWithImages();
    }
}
