namespace GameDomain.Items
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems();
    }
}
