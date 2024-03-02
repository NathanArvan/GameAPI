namespace GameDomain.Tokens
{
    public class TokenService
    {
        private ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<List<Token>> GetTokens()
        {
            return await _tokenRepository.GetTokens();
        }

        public async Task<Token> CreateToken(Token token)
        {
            return await _tokenRepository.InsertToken(token);
        }
    }
}
