using GameDomain.Characters;
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
        public async Task<List<Character>> GetCharacters([FromQuery]CharacterQueryParameters parameters)
        {
            return await this.characterService.GetCharacters(parameters);
        }

        [HttpPost("characters")]
        public async Task<Character> CreateCharacter([FromBody] Character character)
        {
            return await this.characterService.CreateCharacter(character);
        }

        [HttpPut("characters/{id}")]
        [Produces("application/json")]
        public async Task<Character> UpdateCharacter([FromBody] Character character)
        {
            return await this.characterService.UpdateCharacter(character);
        }
    }
}
