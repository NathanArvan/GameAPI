using GameDomain.Battles;
using GameDomain.Characters;
using GameDomain.Users;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Dynamic;
using Newtonsoft.Json;

namespace UnitTests
{
    public class CombatHubTests
    {
        [Fact]
        public async void UserJoinedBattleShouldUpdateAllUsers()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var hub = new CombatHub(cache);


            var mockCaller = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();

            mockCaller.Setup(x => x.All).Returns(mockClientProxy.Object);

            hub.Clients = mockCaller.Object;
            
            var testUser = new User() { Name = "test" };
            var payload = new UserJoinedDTO
            {
                battleId = 1,
                user = testUser
            };
            var userPayload = JsonConvert.SerializeObject(payload);

            await hub.UserJoinedBattle(userPayload);
            mockCaller.Verify(clients => clients.All, Times.Once);
        }

        [Fact]
        public async void UserJoinedBattleShouldAddAUserToTheCache()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var hub = new CombatHub(cache);


            var mockCaller = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();

            mockCaller.Setup(x => x.All).Returns(mockClientProxy.Object);

            hub.Clients = mockCaller.Object;

            var testUser = new User() { Name = "test" };
            var payload = new UserJoinedDTO
            {
                battleId = 1,
                user = testUser
            };
            var userPayload = JsonConvert.SerializeObject(payload);

            await hub.UserJoinedBattle(userPayload);

            var currentUsers = hub.GetUsersForBattle(1);

            Assert.Equivalent(new List<User>() { testUser}  , currentUsers);
        }

        [Fact]
        public async void UpdateCharacterShouldUpdateAnExsistingCharacter()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var hub = new CombatHub(cache);

            var mockCaller = new Mock<IHubCallerClients>();
            var mockClientProxy = new Mock<IClientProxy>();

            mockCaller.Setup(x => x.All).Returns(mockClientProxy.Object);

            hub.Clients = mockCaller.Object;

            var testCharacter = new Character() { Name = "test", CharacterId = 1, HitPoints = 10 };
            var payload = new CharacterMessageDTO() { battleId = 1, Character = testCharacter };
            var characterString = JsonConvert.SerializeObject(payload);

            await hub.CharacterJoinedBattle(characterString);

            var currentCharacters = hub.GetCharactersForBattle(1);

            Assert.Equal(10, currentCharacters.First().HitPoints);

            var characterUpdate = new Character() { Name = "test", CharacterId=1, HitPoints = 5 };
            payload.Character = characterUpdate;
            var updateString = JsonConvert.SerializeObject(payload);

            await hub.CharacterUpdated(updateString);
            currentCharacters = hub.GetCharactersForBattle(1);

            Assert.Equal(5, currentCharacters.First().HitPoints);
        }
    }
}
