namespace GameDomain.Maps
{
    public class MapService
    {
        private IMapRepsitory _mapRepository;

        public MapService(IMapRepsitory mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public async Task<List<Map>> GetMaps()
        {
            return await _mapRepository.GetMaps();
        }

        public async Task<Map> GetMap(int id)
        {
            return await _mapRepository.GetMap(id);
        }

        public async Task<Map> CreateMap(Map map)
        {
            return await _mapRepository.InsertMap(map);
        }

        public async Task<Map> UpdateMap(Map map)
        {
            var id = map.MapId;
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var found = await _mapRepository.GetMap(map.MapId.Value);
            if (found.Length== 0)
            {
                throw new InvalidOperationException("No record found");
            }
            var updatedMap = this.UpdateMapValues(found, map);
            await _mapRepository.UpdateMap(updatedMap);
            return updatedMap;

        }

        private Map UpdateMapValues(Map foundMap, Map incomingMap)
        {
            foundMap.Width= incomingMap.Width;
            foundMap.Length= incomingMap.Length;
            return foundMap;
        }
    }
}
