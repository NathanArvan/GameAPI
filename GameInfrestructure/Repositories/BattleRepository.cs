using GameDomain.Abilities;
using GameDomain.Battle;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private GameContext _context;

        public BattleRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<Battle> GetBattle(int battleId)
        {
            var result = await _context.Batttles
                    .Where(b => b.BattleId == battleId)
                    .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<Battle> CreateBattle(Battle battle)
        {
            _context.Batttles.Add(battle);
            await _context.SaveChangesAsync();
            return battle;
        }

        public async Task<Battle> UpdateBattle(Battle battle)
        {
            _context.Batttles.Update(battle);
            await _context.SaveChangesAsync();
            return battle;
        }

        public async void DeleteBattle(Battle battle)
        {
            _context.Batttles.Remove(battle);
            await _context.SaveChangesAsync();
        }
    }
}
