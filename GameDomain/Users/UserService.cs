namespace GameDomain.Users
{
    public class UserService
    {
        private IUserRepository _repository;
        public UserService(IUserRepository userRepository) {
            _repository = userRepository;
        }

        public async Task<List<User>> GetUsers(UserSearchParameters searchParameters)
        {
            return await _repository.GetUsers(searchParameters);
        }

        public async Task<User> CreateUser(User user)
        {
            return await _repository.CreateUser(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            var found = await GetUsers(new UserSearchParameters() { emails = new string[1] { user.Email } });
            var record = found.FirstOrDefault();
            record.Name = user.Name;
            return await _repository.UpdateUser(record);
        }
    }
}
