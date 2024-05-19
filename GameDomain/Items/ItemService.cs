namespace GameDomain.Items
{
    public class ItemService
    {
        private IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository) { _itemRepository = itemRepository; }

        public async Task<List<Item>> GetItems()
        {
            return await _itemRepository.GetItems();
        }

        public async Task<Item> CreateItem(Item item)
        {
            return await _itemRepository.CreateItem(item);
        }

        public async Task<Item> UpdateItem(Item item)
        {
            return await _itemRepository.UpdateItem(item);

            // for ability in abilities

            // get ability from ability repo, add relationship to item to list.
        }
    }
}
