using GameDomain;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    public class CharacterController : Controller
    {
        [HttpGet("characters")]
        [Produces("application/json")]
        public Task<List<Character>> GetCharacters()
        {
            return Task.FromResult(new List<Character>());
            // return new List<Character>() { new Character() { Name = "Test" } };
        }

    }
}
