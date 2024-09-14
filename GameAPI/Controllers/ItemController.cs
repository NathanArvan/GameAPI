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
        public async Task<List<Item>> GetItems(ItemQueryParameters parameters)
        {
            return await _itemService.GetItems(parameters);
        }

        [HttpPost("items")]
        public async Task<Item> CreateItem([FromBody] CreateItemDTO item)
        {
            return await _itemService.CreateItem(item);
        }

        [HttpPut("items/{id}")]
        public async Task<Item> UpdateItem([FromBody] Item item)
        {
            return await _itemService.UpdateItem(item);
        }
    }
}
