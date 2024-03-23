using GameDomain.Maps;
using GameInfrestructure.Repositories;
using GameInfrestructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDomain;
using GameDomain.Characters;

namespace UnitTests
{
    public  class CharacterTests
    {
        private SqliteConnection _connection;
        private DbContextOptions<GameContext> _contextOptions;

        public CharacterTests()
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
                var repo = new CharacterRepository(context);
                var service = new CharacterService(repo);
                var testCharacter = new Character();
                await service.CreateCharacter(testCharacter);
                var results = await repo.Query();
                Assert.Single(results);
            }
        }
    }
}
