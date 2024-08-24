using GameDomain.Characters;
using GameDomain.Maps;
using GameDomain.Tokens;
using GameInfrestructure;
using GameInfrestructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class TokenTests
    {
        private SqliteConnection _connection;
        private DbContextOptions<GameContext> _contextOptions;

        public TokenTests()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<GameContext>()
                .UseSqlite(_connection)
                .Options;


        }
        GameContext CreateContext() => new GameContext(_contextOptions);

        public void Dispose() => _connection.Dispose();
        [Fact]
        public async Task ATokenCanBeAssignedToAMapWithAPosition()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();

                var repo = new TokenRepository(context);
                var service = new TokenService(repo);
                var testToken = new TokenDTO();
                var savedToken = await service.CreateToken(testToken);

                var mapRepo = new MapRepository(context);
                var mapService = new MapService(mapRepo);
                var testMap = new Map() { Length = 5, Width = 5};
                await mapService.CreateMap(testMap);

                savedToken.MapId = testMap.MapId;
                savedToken.xPosition = 1;
                savedToken.yPosition = 1;

                await service.UpdateToken(savedToken);

                var results = await repo.GetTokens(new TokenSearchParameters() { MapIds = new int[1] { (int)testMap.MapId } });
                var found = results.FirstOrDefault();
                Assert.True(found.xPosition == 1 && found.yPosition == 1);
            }
        }
    }
}
