namespace GameDomain.Users
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<List<User>> GetUsers(UserSearchParameters parameters);
    }
}
