﻿using GameDomain.Battles;
using GameDomain.Users;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class UserController
    {
        private UserService _service;

        public UserController(UserService service) { _service = service; }

        [HttpGet("users/{id}")]
        public async Task<User> GetAbilities(int id)
        {
            var result = await _service.GetUsers(new UserSearchParameters() { });
            return result.FirstOrDefault();
        }

        [HttpPost("users")]
        public async Task<User> CreateUser([FromBody] User user)
        {
            var result = await _service.CreateUser(user);
            return result;
        }

        [HttpPut("users/{id}")]
        public async Task<User> UpdateUser([FromBody] User user)
        {
            var result = await _service.UpdateUser(user);
            return result;
        }
    }
}
