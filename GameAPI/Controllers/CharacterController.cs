using GameDomain;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    public class CharacterController : Controller
    {
        private CharacterService characterService;

        public CharacterController(CharacterService characterService)
        {
            this.characterService = characterService;
        }

        [HttpGet("characters")]
        [Produces("application/json")]
        public Task<List<Character>> GetCharacters()
        {
            return this.characterService.GetCharacters();
        }

    }
}
