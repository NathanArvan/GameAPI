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

        public async Task<Ability> CreateAbility(Ability ability)
        {
            _context.Abilities.Add(ability);
            await _context.SaveChangesAsync();
            return ability;
        }

        public async Task<Ability> UpdateAbility(Ability ability)
        {
            _context.Abilities.Update(ability);
            await _context.SaveChangesAsync();
            return ability;
        }
    }
}
