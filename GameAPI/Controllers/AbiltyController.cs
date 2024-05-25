using GameDomain.Abilities;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class AbiltyController : Controller
    {
        private AbilityService _service;

        public AbiltyController(AbilityService service) { _service = service; }

        [HttpGet("abilities")]
        public async Task<List<Ability>> GetAbilities(AbilityQueryParameteres abilityQueryParameteres)
        {
            var result = await _service.GetAbilities(abilityQueryParameteres);
            return result;
        }

        [HttpPost("abilities")]
        public async Task<Ability> CreateAbility([FromBody]Ability ability)
        {
            var result =  await _service.CreateAbility(ability);
            return result;
        }

        [HttpPut("abilities/{id}")]
        public async Task<Ability> UpdateAbility([FromBody] Ability ability)
        {
            var result = await _service.UpdateAbility(ability); 
            return result;
        }
    }
}
