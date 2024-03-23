namespace GameDomain.Characters
{
    public interface ICharacterRepository
    {
        public Task<List<Character>> Query();

        public Task<Character> CreateCharacter(Character character);

        public Task<Character> UpdateCharacter(Character character);
    }
}
