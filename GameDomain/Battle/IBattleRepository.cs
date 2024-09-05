namespace GameDomain.Battle
{
    public interface IBattleRepository
    {
        public Task<Battle> GetBattle(int battleId);
        public Task<Battle> CreateBattle(Battle battle);
        public Task<Battle> UpdateBattle(Battle battle);
        public void DeleteBattle(Battle battle);
    }
}
