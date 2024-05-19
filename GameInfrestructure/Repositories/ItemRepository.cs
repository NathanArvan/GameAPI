using GameDomain.Items;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GameContext _context;
        public ItemRepository(GameContext context) {
            _context = context;
        }

        public async Task<List<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> CreateItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
