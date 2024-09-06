﻿using GameDomain.Characters;
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

        public async Task<List<Character>> Query()
        {
            return await _context.Characters.ToListAsync();
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
