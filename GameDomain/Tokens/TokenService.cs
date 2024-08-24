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
            return await _tokenRepository.GetTokens( new TokenSearchParameters());
        }

        public async Task<Token> CreateToken(TokenDTO token)
        {
            var result = await _tokenRepository.InsertToken(token);

            if (token.File != null)
            {
                using (var stream = new MemoryStream())
                {
                    token.File.CopyTo(stream);
                    var file = stream.ToArray();
                    var image = new TokenImage() { TokenId = result.TokenId, Image = file };
                    await _tokenRepository.InsertTokenImage(image);
                }
            }
            return result;
        }

        public async Task<List<Token>> GetTokensWithImages()
        {
            return await _tokenRepository.GetTokensWithImages();
        }

        public async Task<Token> UpdateToken(Token token)
        {
            if(token.TokenId== null)
            {
                throw new ArgumentNullException("Token Id not provided");
            }
            var dbRecord = await _tokenRepository.GetTokens(new TokenSearchParameters() { TokenIds = new int[1] {(int)token.TokenId} });
            if (dbRecord.Count == 0)
            {
                throw new ArgumentException("No Record Found");
            }
            var originalToken = dbRecord[0];
            originalToken.UpdateToken(token);
            var result = await _tokenRepository.UpdateToken(originalToken);
            return result;
        }
    }
}
