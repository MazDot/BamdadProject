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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInsertDto categoryDto)
        {
            var output = await categoryServices.Insert(categoryDto);
            return Ok(output);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Category category)
        {
            await categoryServices.Delete(category);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await categoryServices.Get(id);
            return Ok(output);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await categoryServices.Update(category);
            return Ok();
        }
    }
}
