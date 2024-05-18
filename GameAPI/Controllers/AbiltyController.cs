using GameDomain.Abilities;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class AbiltyController : Controller
    {
        private AbilityService _service;

        public AbiltyController(AbilityService service) { _service = service; }

        [HttpGet("abilities")]
        public async Task<List<Ability>> GetAbilities()
        {
            var result = await _service.GetAbilities();
            return result;
        }
    }
}
