using GameDomain.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameInfrestructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private GameContext _gameContext;

        public TokenRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<List<Token>> GetTokens(TokenSearchParameters parameters)
        {
            if (parameters.TokenIds.Length == 0 && parameters.MapIds.Length == 0)
            {
                return await _gameContext.Tokens.ToListAsync();
            }
            else
            {
                return await _gameContext.Tokens
                    .Where(t => parameters.TokenIds.ToList().Contains((int)t.TokenId) || parameters.TokenIds.Length == 0)
                    .Where(t => parameters.MapIds.ToList().Contains((int)t.MapId) || parameters.MapIds.Length == 0)
                    .ToListAsync();
            }
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

        public async Task<Token> UpdateToken(Token token)
        {
            _gameContext.Tokens.Update(token);
            await _gameContext.SaveChangesAsync();
            return token;
        }
    }
}
