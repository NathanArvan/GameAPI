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
        public async Task<List<Character>> GetCharacters()
        {
            return await this.characterService.GetCharacters();
        }

        [HttpPut("characters/{id}")]
        [Produces("application/json")]
        public async Task<Character> UpdateCharacter(Character character)
        {
            return await this.characterService.UpdateCharacter(character);
        }
    }
}
