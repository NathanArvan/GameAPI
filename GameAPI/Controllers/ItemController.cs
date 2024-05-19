using GameDomain.Items;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class ItemController : Controller
    {
        private ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("items")]
        public async Task<List<Item>> GetItems()
        {
            return await _itemService.GetItems();
        }
    }
}
