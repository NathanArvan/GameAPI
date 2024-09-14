using GameDomain.Abilities;

namespace GameDomain.Items
{
    public class ItemService
    {
        private IItemRepository _itemRepository;
        private IAbilityRepository _abilityRepository;

        public ItemService(IItemRepository itemRepository, IAbilityRepository abilityRepository) { 
            _itemRepository = itemRepository;
            _abilityRepository = abilityRepository;
        }

        public async Task<List<Item>> GetItems(ItemQueryParameters parameters)
        {
            var result = await _itemRepository.GetItems(parameters);
            result.ForEach(item =>
            {
                item.Abilities.ForEach(ability =>
                {
                    ability.Items = new List<Item>();
                });
            });
            return result;
        }

        public async Task<Item> CreateItem(CreateItemDTO itemDTO)
        {
            var item = new Item()
            {
                Name = itemDTO.Name,
                Weight = itemDTO.Weight,
            };
            if (itemDTO.AbilityIds.Any())
            {
                var foundAbilities = await _abilityRepository.GetAbilities(new AbilityQueryParameteres() { AbilityIds = itemDTO.AbilityIds.ToArray() });
                item.Abilities = foundAbilities;
            }
            var result = await _itemRepository.CreateItem(item);
            result.Abilities.ForEach(ability =>
            {
                ability.Items = new List<Item>();
            });
            return result;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            return await _itemRepository.UpdateItem(item);

            // for ability in abilities

            // get ability from ability repo, add relationship to item to list.
        }
    }
}
