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
    public class StoreController : ControllerBase
    {
        private readonly IStoreServices storeServices;
        public StoreController(IStoreServices storeServices)
        {
            this.storeServices = storeServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoreInsertDto storeDto)
        {
            var output = await storeServices.Insert(storeDto);
            return Ok(output);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Store store)
        {
            await storeServices.Delete(store);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await storeServices.Get(id);
            return Ok(output);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Store store)
        {
            await storeServices.Update(store);
            return Ok();
        }
    }
}
