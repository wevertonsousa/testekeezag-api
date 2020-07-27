using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Services;
using Keezag.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Keezag.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Save([FromBody]User entity)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.Create(entity);
                return Ok(user);
            }
            return BadRequest(entity);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]string id)
        {
            User user = _userService.Get(id);

            if (user != null)
                return Ok(user);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]string id, [FromBody]User entity)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(id, entity);
                return Ok(entity);
            }
            return BadRequest(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            _userService.Remove(id);
            return Ok();
        }
    }
}