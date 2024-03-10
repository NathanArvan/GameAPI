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

        public async Task<Token> CreateToken(TokenDTO token)
        {
            var result = await _tokenRepository.InsertToken(token);

            using (var stream = new MemoryStream())
            {
                token.File.CopyTo(stream);
                var file = stream.ToArray();
                var image = new TokenImage() { TokenId = result.TokenId, Image = file };
                await _tokenRepository.InsertTokenImage(image);
            }

            return result;
        }

        public async Task<List<Token>> GetTokensWithImages()
        {
            return await _tokenRepository.GetTokensWithImages();
        }
    }
}
