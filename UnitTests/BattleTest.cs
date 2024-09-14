using GameDomain.Battles;
using GameDomain.Characters;
using GameInfrestructure;
using GameInfrestructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace UnitTests
{
    public class BattleTest
    {
        private SqliteConnection _connection;
        private DbContextOptions<GameContext> _contextOptions;

        public BattleTest() {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<GameContext>()
                .UseSqlite(_connection)
                .Options;
        }

        GameContext CreateContext() => new GameContext(_contextOptions);

        public void Dispose() => _connection.Dispose();

        [Fact]
        public async Task CreateBattleShouldReturnABattleObject()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                var repo = new BattleRepository(context);
                var characterRepo = new CharacterRepository(context);
                var characterService = new CharacterService(characterRepo);
                var service = new BattleService(characterService, repo);
                var createdBattle = await service.CreateBattle();
                var results = await repo.GetBattle((int)createdBattle.BattleId);
                Assert.IsType<Battle>(results);
            }
        }
    }
}
