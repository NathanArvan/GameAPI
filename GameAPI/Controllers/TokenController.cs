using GameDomain.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private TokenService _tokenService;
        private FileManager _fileManager;
        public TokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
            _fileManager= new FileManager();
        }

        [HttpGet("tokens")]
        public async Task<List<Token>> GetTokens()
        {
            return await _tokenService.GetTokens();
        }

        [HttpGet("tokens/tokensWithImages")] 
        public async Task<List<object>> GetTokensWithImages()
        {
            var result = await _tokenService.GetTokensWithImages();
            var items = new List<object>();
            foreach (var token in result)
            {
                FileContentResult? image;
                if(token.Image != null)
                {
                    image = await _fileManager.GetFileAsync(this, token.Image.Image, "test.jpeg", "image/jpeg");
                } else
                {
                    image = null;
                }
                
                var item = new { image, token.TokenId, token.MapId, token.xPosition, token.yPosition };
                items.Add(item);
            }
            return items;
        }

        [HttpPost("tokens")]
        public async Task<Token> CreateToken([FromForm] TokenDTO token)
        {
            return await _tokenService.CreateToken(token);
        }


        [HttpPut("tokens")]
        public async Task<Token> UpdateToken([FromBody] Token token)
        {
            return await _tokenService.UpdateToken(token);
        }
    }
}
