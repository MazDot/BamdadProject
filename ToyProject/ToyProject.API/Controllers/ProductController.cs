using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toy.Entities;
using Toy.Services.Dto.Input;
using Toy.Services.Services;
using ToyProject.API.Validators;

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
            ProductValidator validator = new ProductValidator();
            ValidationResult results = validator.Validate(productDto);
            if (results.IsValid)
            {
                var output = await productServices.Insert(productDto);
                return Ok(output);
            }
            return BadRequest(results.Errors);
            
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
