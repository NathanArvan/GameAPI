using GameDomain.Characters;

namespace GameDomain.Battles
{
    public class BattleService
    {
        private IBattleRepository _battleRepository;
        private CharacterService _characterService;
        public BattleService( CharacterService characterService, IBattleRepository battleRepository)
        {
            _characterService = characterService;
            _battleRepository = battleRepository;
        }

        public Task<Battle> GetBattle(int battleId) { 
            return _battleRepository.GetBattle(battleId);
        }

        public async Task<Battle> CreateBattle() {
            var battle = new Battle();
            return await _battleRepository.CreateBattle(battle);
        }

        public async Task<Battle> UpdateBattle(Battle battle) {
            var found = await _battleRepository.GetBattle((int)battle.BattleId);
            if (found != null) { 
                found.Turn = battle.Turn;
            }
            return await _battleRepository.UpdateBattle(found);
        }

        public void DeleteBattle() {}
    }
}
