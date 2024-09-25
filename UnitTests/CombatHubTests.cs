using GameDomain.Battles;
using GameDomain.Users;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Dynamic;
using System.Text.Json;

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
            var userString = JsonSerializer.Serialize(testUser);

            await hub.UserJoinedBattle(1, userString);
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
            var userString = JsonSerializer.Serialize(testUser);

            await hub.UserJoinedBattle(1, userString);

            var currentUsers = hub.GetUsersForBattle(1);

            Assert.Equivalent(new List<User>() { testUser}  , currentUsers);
        }
    }
}
