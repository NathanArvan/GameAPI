namespace GameDomain.Characters
{
    public class CharacterService
    {
        private ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Character>> GetCharacters(CharacterQueryParameters parameters)
        {
            return _repository.Query(parameters);
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            return await _repository.CreateCharacter(character);
        }

        public async Task<List<Character>> CreateCharacters(List<Character> characters)
        {
            return await _repository.CreateCharacters(characters);
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            var query = await _repository.Query(new CharacterQueryParameters() { characterIds = new int[1] { character.CharacterId } });

            var found = query.FirstOrDefault();

            found.xPosition = character.xPosition;
            found.yPosition = character.yPosition;
            found.HitPoints = character.HitPoints;  
            
            return await _repository.UpdateCharacter(character);
        }
    }
}
