using GameDomain.Abilities;
using GameDomain.Characters;
using GameDomain.Items;
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
    public class ItemTests
    {
        private SqliteConnection _connection;
        private DbContextOptions<GameContext> _contextOptions;

        public ItemTests()
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
        public async Task AnItemShouldHaveItsListOfAbilities()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                //await context.Database.

                var abilityRepo = new AbilityRepository(context);
                var abilityService = new AbilityService(abilityRepo);
                var testAbility = new Ability() { Name = "Test Ability" };

                var repo = new ItemRepository(context);
                var service = new ItemService(repo, abilityRepo);
                var testItem = new Item() {Name = "Test Item", Abilities = new List<Ability>() { testAbility} };
                await repo.CreateItem(testItem);
                var results = await service.GetItems(new ItemQueryParameters() { itemIds = new int[1] { (int)testItem.ItemId } });
                Assert.Equal("Test Ability", results.First().Abilities.First().Name);
            }

        }
    }
}
