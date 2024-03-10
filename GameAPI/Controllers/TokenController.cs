using GameDomain.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    public class TokenController
    {
        private TokenService _tokenService;
        public TokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("tokens")]
        public async Task<List<Token>> GetTokens()
        {
            return await _tokenService.GetTokens();
        }
        

        [HttpPost("tokens")]
        //[Consumes("multipart/form-data")]
        public async Task<Token> CreateToken([FromForm] TokenDTO token)
        {
            return await _tokenService.CreateToken(token);
        }
    }
}
