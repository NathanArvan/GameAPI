namespace GameDomain.Classes
{
    public class ClassService
    {
        private IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository) {
            _classRepository = classRepository;
        }

        public async Task<List<Class>> GetClasses() { return await _classRepository.GetClasses(); }
    }
}
