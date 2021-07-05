using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Services.Dto.Input;
using Toy.Services.Services;

namespace ToyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserInsertDto userDto)
        {
                var output = await userServices.Insert(userDto);
                return Ok(output);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(User user)
        {
            await userServices.Delete(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await userServices.Get(id);
            return Ok(output);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await userServices.Update(user);
            return Ok();
        }

    }
}
