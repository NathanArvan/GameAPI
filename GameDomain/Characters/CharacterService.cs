namespace GameDomain.Characters
{
    public class CharacterService
    {
        private ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Character>> GetCharacters()
        {
            return _repository.Query();
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            return await _repository.CreateCharacter(character);
        }
    }
}
