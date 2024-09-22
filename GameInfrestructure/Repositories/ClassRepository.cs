using GameDomain.Classes;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private GameContext _gameContext;
        public ClassRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<List<Class>> GetClasses()
        {
            return await _gameContext.Classes.ToListAsync();
        }
    }
}
