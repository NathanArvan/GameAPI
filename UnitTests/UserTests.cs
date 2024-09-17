using GameDomain.Characters;
using GameInfrestructure.Repositories;
using GameInfrestructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using GameDomain.Users;

namespace UnitTests
{
    public class UserTests
    {
        private SqliteConnection _connection;
        private DbContextOptions<GameContext> _contextOptions;

        public UserTests()
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
        public async Task CreateUserShouldReturnAUserObject()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                var repo = new UserRepository(context);
                var service = new UserService(repo);
                var testUser = new User();
                await service.CreateUser(testUser);
                var results = await repo.GetUsers(new UserSearchParameters());
                Assert.Single(results);
            }
        }

        [Fact]
        public async Task UpdateUserShouldChangeUserValues()
        {
            using (var context = CreateContext())
            {
                await context.Database.EnsureCreatedAsync();
                var repo = new UserRepository(context);
                var service = new UserService(repo);
                var testUser = new User() { Name = "Test User",Email = "test@domain.com" };
                await repo.CreateUser(testUser);
                testUser.Name = "Update";
                var result = await service.UpdateUser(testUser);
                Assert.Equal("Update", result.Name);
            }
        }
    }
}
