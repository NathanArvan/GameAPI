namespace GameDomain.Abilities
{
    public class AbilityService
    {
        private IAbilityRepository _repo;
        
        public AbilityService(IAbilityRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Ability>> GetAbilities()
        {
            return await _repo.GetAbilities();
        }
    }
}
