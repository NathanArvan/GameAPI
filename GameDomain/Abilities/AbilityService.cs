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

        public async Task<Ability> CreateAbility(Ability ability)
        {
            return await _repo.CreateAbility(ability);
        }

        public async Task<Ability> UpdateAbility(Ability ability)
        {
            return await _repo.UpdateAbility(ability);
        }
    }
}
