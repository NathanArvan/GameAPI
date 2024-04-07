namespace GameDomain.Maps
{
    public interface IMapRepsitory
    {
        public Task<List<Map>> GetMaps();

        public Task<Map> GetMap(int madId);

        public Task<Map> InsertMap(Map map);

        public Task<Map> UpdateMap(Map map);
    }
}
