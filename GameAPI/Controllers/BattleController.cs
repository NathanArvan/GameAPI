using GameDomain.Battles;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class BattleController : Controller
    {
        private BattleService _service;

        public BattleController(BattleService service) { _service = service; }

        [HttpGet("battle/{id}")]
        public async Task<Battle> GetAbilities(int id)
        {
            var result = await _service.GetBattle(id);
            return result;
        }

        [HttpPost("battle")]
        public async Task<Battle> CreateBattle()
        {
            var result = await _service.CreateBattle();
            return result;
        }

        [HttpPut("battle/{id}")]
        public async Task<Battle> UpdateBattle([FromBody] Battle battle)
        {
            var result = await _service.UpdateBattle(battle);
            return result;
        }
    }
}
