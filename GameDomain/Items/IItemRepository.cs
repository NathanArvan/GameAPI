namespace GameDomain.Items
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems(ItemQueryParameters parameters);

        public Task<Item> CreateItem(Item item);

        public Task<Item> UpdateItem(Item item);
    }
}
