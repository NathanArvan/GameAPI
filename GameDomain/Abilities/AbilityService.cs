namespace GameDomain.Abilities
{
    public class AbilityService
    {
        private IAbilityRepository _repo;
        
        public AbilityService(IAbilityRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Ability>> GetAbilities(AbilityQueryParameteres abilityQueryParameteres)
        {
            return await _repo.GetAbilities(abilityQueryParameteres);
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
