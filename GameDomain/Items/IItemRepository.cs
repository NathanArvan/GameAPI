namespace GameDomain.Items
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems();

        public Task<Item> CreateItem(Item item);

        public Task<Item> UpdateItem(Item item);
    }
}
