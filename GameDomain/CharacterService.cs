namespace GameDomain
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
    }
}
