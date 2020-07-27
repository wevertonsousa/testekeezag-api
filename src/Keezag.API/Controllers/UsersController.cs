using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Keezag.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]int page = 0, [FromQuery]int pageSize = 5)
        {
            GetUsersResult user = _userService.Get(page, pageSize);

            if (user != null)
                return Ok(user);

            return NoContent();
        }
    }
}