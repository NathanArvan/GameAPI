using GameDomain.Characters;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private GameContext _context;

        public CharacterRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<List<Character>> Query(CharacterQueryParameters parameters)
        {
            if (parameters.characterIds.Length == 0 && parameters.battleIds.Length == 0)
            {
                return await _context.Characters.ToListAsync();
            }
            return await _context.Characters
                .Where(c => parameters.characterIds.Contains(c.CharacterId) ||
                         parameters.battleIds.Contains((int)c.BattleId))
                .ToListAsync();
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<List<Character>> CreateCharacters(List<Character> characters)
        {
            _context.Characters.AddRange(characters);
            await _context.SaveChangesAsync();
            return characters;
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
