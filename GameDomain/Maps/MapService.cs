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
    }
}
