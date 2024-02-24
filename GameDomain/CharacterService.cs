namespace GameDomain
{
    public class CharacterService
    {
        public Task<List<Character>> GetCharacters()
        {
            return Task.FromResult(new List<Character>());
        }
    }
}
