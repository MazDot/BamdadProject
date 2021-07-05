using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;
using Toy.Services.Services;
using ToyProject.API.Validators;

namespace ToyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices contactServices;
        public ContactController(IContactServices contactServices)
        {
            this.contactServices = contactServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactInsertDto contactDto)
        {
            ContactValidator validator = new ContactValidator();
            ValidationResult results = validator.Validate(contactDto);
            if (results.IsValid)
            {
                var output = await contactServices.Insert(contactDto);
                return Ok(output);
            }
            return BadRequest(results.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Contact contact)
        {
            await contactServices.Delete(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await contactServices.Get(id);
            return Ok(output);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
        {
            await contactServices.Update(contact);
            return Ok();
        }


    }
}
