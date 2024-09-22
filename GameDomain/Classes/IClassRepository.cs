namespace GameDomain.Classes
{
    public interface IClassRepository
    {
        public Task<List<Class>> GetClasses();
    }
}
