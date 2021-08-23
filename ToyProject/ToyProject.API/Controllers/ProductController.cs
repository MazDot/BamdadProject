using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowAll")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;
        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [Authorize]
        [HttpPost("addProduct")]
        public async Task<IActionResult> Create([FromBody] ProductInsertDto productDto)
        {
            string role = HttpContext.User.FindFirstValue("Role");
            if (role == "Customer")
            {
                return Unauthorized();
            }
            int userId = int.Parse(HttpContext.User.FindFirstValue("id"));
            ProductValidator validator = new ProductValidator();
            ValidationResult results = validator.Validate(productDto);
            if (results.IsValid)
            {
                var output = await productServices.Insert(productDto, userId);
                return Ok(output);
            }
            return BadRequest(results.Errors);

        }

        [Authorize]
        [HttpGet("allProducts")]
        public async Task<IEnumerable<Product>> GetAllProductsByUserId()
        {
            int userId = int.Parse(HttpContext.User.FindFirstValue("id"));
            var output = await productServices.GetAllByUserId(userId);
            return output;
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(Product product)
        {
            await productServices.Delete(product);
            return Ok();
        }

        [HttpGet("categorySearch/{category}")]
        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            var output = await productServices.GetByCategory(category);
            return output;

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await productServices.Get(id);
            return Ok(output);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await productServices.Update(product);
            return Ok();
        }

    }
}
