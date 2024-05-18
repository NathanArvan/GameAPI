namespace GameDomain.Abilities
{
    public interface IAbilityRepository
    {
        public Task<List<Ability>> GetAbilities();
    }
}
