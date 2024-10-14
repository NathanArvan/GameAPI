using GameDomain.Users;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private GameContext _context;

        public UserRepository(GameContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user) { 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetUsers (UserSearchParameters parameters)
        {
            if (parameters.emails.Length == 0)
            {
                return await _context.Users.ToListAsync();
            }
            return await _context.Users
                .Where(
                    u => parameters.emails.Contains(u.Email) ||
                     parameters.userIds.Contains((int)u.UserId)
                )
                .ToListAsync();
        }
    }
}
