namespace GameDomain.Characters
{
    public interface ICharacterRepository
    {
        public Task<List<Character>> Query(CharacterQueryParameters parameters);

        public Task<Character> CreateCharacter(Character character);

        public Task<List<Character>> CreateCharacters(List<Character> characters);

        public Task<Character> UpdateCharacter(Character character);
    }
}
