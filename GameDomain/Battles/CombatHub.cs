using GameDomain.Characters;
using GameDomain.Users;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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

        public async Task UserJoinedBattle(string payload)
        {
            var parsedPayload = Regex.Unescape(payload);
            UserJoinedDTO? dto = JsonConvert.DeserializeObject<UserJoinedDTO>(parsedPayload);
            var battleId = dto.battleId;
            var newUser = dto.user;
            var currentUsers = GetUsersForBattle(battleId); 
            if (newUser != null)
            {
                currentUsers.Add(newUser);
            }
            var serializedUsers = JsonConvert.SerializeObject(currentUsers); 
            SetBattleUsers(battleId, currentUsers);
            await Clients.All.SendAsync("UserJoinedBattle", serializedUsers);
        }

        private void SetBattleUsers(int battleId, List<User> users)
        {
             _memoryCache.Set($"battle-${battleId}-users", users);
        }
        
        public List<User> GetUsersForBattle(int battleId)
        {
            List<User> users;
            if (!_memoryCache.TryGetValue($"battle-${battleId}-users", out users)) { 
                users = new List<User>();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1));
                _memoryCache.Set($"battle-${battleId}-users", users);
            }
            return users;
        }

        public async Task CharacterJoinedBattle(string payload)
        {

        }

        private void SetBattleCharacters(int battleId, List<CharacterClass> characters)
        {
            _memoryCache.Set($"battle-${battleId}-characters", characters);
        }

        public List<Character> GetCharactersForBattle(int battleId)
        {
            List<Character> characters;
            if (!_memoryCache.TryGetValue($"battle-${battleId}-characters", out characters))
            {
                characters = new List<Character>();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1));
                _memoryCache.Set($"battle-${battleId}-characters", characters);
            }
            return characters;
        }
    }
}
