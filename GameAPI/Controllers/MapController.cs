﻿using GameDomain.Maps;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    public class MapController
    {
        private MapService _mapService;

        public MapController(MapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet("maps")]
        [Produces("application/json")]
        public async Task<List<Map>> GetMaps()
        {
            return await _mapService.GetMaps();
        }

        [HttpGet("maps/{id}")]
        [Produces("application/json")]
        public async Task<Map> GetMap(int id)
        {
            return await _mapService.GetMap(id);
        }

        [HttpPost("maps")]
        [Produces("application/json")]
        public async Task<Map> CreateMap(Map map)
        {
            return await _mapService.CreateMap(map);
        }

        [HttpPut("maps")]
        [Produces("application/json")]
        public async Task<Map> UpdateMap(Map map)
        {
            return await _mapService.UpdateMap(map);
        }
    }
}
