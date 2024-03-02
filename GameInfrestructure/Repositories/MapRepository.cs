using GameDomain.Maps;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class MapRepository : IMapRepsitory
    {
        private GameContext _gameContext;
        public MapRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<List<Map>> GetMaps()
        {
            return await _gameContext.Maps.ToListAsync();
        }

        public async Task<Map> GetMap(int mapId)
        {
            var result = await _gameContext.Maps
                .Where(m => m.MapId.Equals(mapId))
                .Include(m => m.Tokens)
                .ToListAsync();
            return result.First();
        }

        public async Task<Map> InsertMap(Map map)
        {
            _gameContext.Maps.Add(map);
            await _gameContext.SaveChangesAsync();
            return map;
        }
    }
}
