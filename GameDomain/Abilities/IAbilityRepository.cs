namespace GameDomain.Abilities
{
    public interface IAbilityRepository
    {
        public Task<List<Ability>> GetAbilities(AbilityQueryParameteres abilityQueryParameteres);
        public Task<Ability> CreateAbility(Ability ability);
        public Task<Ability> UpdateAbility(Ability ability);
    }
}
