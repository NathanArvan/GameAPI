namespace GameDomain
{
    public interface ICharacterRepository
    {
        public Task<List<Character>> Query();
    }
}
