using GameDomain.Abilities;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class AbilityRepository : IAbilityRepository
    {
        private GameContext _context;

        public AbilityRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<List<Ability>> GetAbilities()
        {
            return await _context.Abilities.ToListAsync();
        }
    }
}
