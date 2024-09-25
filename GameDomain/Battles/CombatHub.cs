using GameDomain.Users;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace GameDomain.Battles
{
    public class CombatHub : Hub
    {
        private readonly IMemoryCache _memoryCache;

        public CombatHub(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public async Task UserJoinedBattle(int battleId, string user)
        {
            var newUser = JsonSerializer.Deserialize<User>(user); 
            var currentUsers = GetUsersForBattle(battleId); 
            if (newUser != null)
            {
                currentUsers.Add(newUser);
            }
            var serializedUsers = JsonSerializer.Serialize(currentUsers);
            SetBattleUsers(battleId, currentUsers);
            await Clients.All.SendAsync("UserJoinedBattle", serializedUsers);
        }

        private void SetBattleUsers(int battleId, List<User> users)
        {
             _memoryCache.Set(battleId, users);
        }
        
        public List<User> GetUsersForBattle(int battleId)
        {
            List<User> users;
            if (!_memoryCache.TryGetValue(battleId, out users)) { 
                users = new List<User>();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1));
                _memoryCache.Set(battleId, users);
            }
            return users;
        }
    }
}
