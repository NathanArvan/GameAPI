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
using GameDomain.Abilities;
using GameDomain.Items;

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
        public async Task CreateCharacterShouldReturnACharacterObject()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                var repo = new CharacterRepository(context);
                var service = new CharacterService(repo);
                var testCharacter = new Character();
                await service.CreateCharacter(testCharacter);
                var results = await repo.Query(new CharacterQueryParameters());
                Assert.Single(results);
            }
        }

        [Fact]
        public async Task UpdateCharacterShouldChangeCharacterValues()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                var repo = new CharacterRepository(context);
                var service = new CharacterService(repo);
                var testCharacter = new Character() { HitPoints = 10};
                await repo.CreateCharacter(testCharacter);
                testCharacter.HitPoints = 1;
                var result = await service.UpdateCharacter(testCharacter);
                Assert.Equal(1, result.HitPoints);
            }
        }

        [Fact]
        public async Task ACharacterShouldGetAssignedItemsWithAbilitites()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();

                var abilityRepo = new AbilityRepository(context);
                var abilityService = new AbilityService(abilityRepo);

                var repo = new CharacterRepository(context);
                var service = new CharacterService(repo);

                var itemRepo = new ItemRepository(context);
                var itemService = new ItemService(itemRepo, abilityRepo);


                var testAbility = new Ability() { Name = "Test Ability" };
                testAbility = await abilityRepo.CreateAbility(testAbility);

                var testItem = new Item() { Name = "Test Item", Abilities = new List<Ability>() { testAbility } };
                testItem = await itemRepo.CreateItem(testItem);


                var testCharacter = new Character() { Name = " Test Character", Items = new List<Item>() { testItem } };
                await repo.CreateCharacter(testCharacter);
                var results = await service.GetCharacters(new CharacterQueryParameters());
                var result = results.FirstOrDefault();
                Assert.Equal("Test Ability", result.Items.First().Abilities.First().Name);
            }
        }
    }
}
