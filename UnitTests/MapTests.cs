using GameDomain.Maps;
using GameInfrestructure;
using GameInfrestructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace UnitTests
{
    public class MapTests : IDisposable
    {
        private SqliteConnection _connection;
        private DbContextOptions<GameContext> _contextOptions;

        public MapTests()
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
        public async Task CreateMapShouldReturnAMapObject()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                var repo = new MapRepository(context);
                var service = new MapService(repo);
                var testMap = new Map();
                await service.CreateMap(testMap);
                var results = await repo.GetMaps();
                Assert.Single(results);
            }
        }
    }
}