using GameDomain.Abilities;
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

        public async Task<List<Item>> GetItems(ItemQueryParameters parameters)
        {
            if (parameters.itemIds.Length == 0) {
                return await _context.Items
                    .Include(i => i.Abilities)
                    .ToListAsync();
            }
            return await _context.Items
                .Where(i => parameters.itemIds.Contains((int)i.ItemId))
                .Include(i => i.Abilities)
                .ToListAsync();
        }

        public async Task<Item> CreateItem(Item item)
        {
            _context.Items.Add(item);
            //_context.Abilities.Find
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
