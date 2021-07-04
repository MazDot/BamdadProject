using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toy.Entities;
using Toy.Services.Dto.Input;
using Toy.Services.Services;

namespace ToyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;
        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInsertDto productDto)
        {
            var output = await productServices.Insert(productDto);
            return Created($"ID : {output} + {productDto}", productDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
        {
            await productServices.Delete(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await productServices.Get(id);
            return Ok(output);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await productServices.Update(product);
            return Ok();
        }

    }
}
