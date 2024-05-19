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
    }
}
