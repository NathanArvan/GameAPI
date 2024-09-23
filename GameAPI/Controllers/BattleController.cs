using GameDomain.Battles;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

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

        [HttpGet("battle/{id}/users")]
        public async Task GetUsersInBattle()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private static async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);

                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }
    }
}
