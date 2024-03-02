namespace GameDomain.Tokens
{
    public interface ITokenRepository
    {
        public Task<List<Token>> GetTokens();

        public Task<Token> InsertToken(Token token);
    }
}
