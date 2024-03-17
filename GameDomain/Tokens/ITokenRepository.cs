namespace GameDomain.Tokens
{
    public interface ITokenRepository
    {
        public Task<List<Token>> GetTokens(TokenSearchParameters parameters);

        public Task<Token> InsertToken(Token token);

        public Task<TokenImage> InsertTokenImage(TokenImage image);

        public Task<Token> UpdateToken(Token token);

        public Task<List<Token>> GetTokensWithImages();
    }
}
