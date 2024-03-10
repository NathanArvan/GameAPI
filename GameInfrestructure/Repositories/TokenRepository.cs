using GameDomain.Tokens;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private GameContext _gameContext;

        public TokenRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<List<Token>> GetTokens()
        {
            return await _gameContext.Tokens.ToListAsync();
        }

        public async Task<Token> InsertToken(Token token)
        {
            _gameContext.Tokens.Add(token);
            await _gameContext.SaveChangesAsync();
            return token;
        }

        public async Task<TokenImage> InsertTokenImage(TokenImage image)
        {
            _gameContext.TokenImages.Add(image);
            await _gameContext.SaveChangesAsync();
            return image;
        }

        public async Task<List<Token>> GetTokensWithImages()
        {
            return await _gameContext.Tokens
                .Include(t => t.Image)
                .ToListAsync();
        }
    }
}
