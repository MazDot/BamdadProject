using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;
using Toy.Services.Services;

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
            var output = await contactServices.Insert(contactDto);
            return Created($"ID : {output} + {contactDto}", contactDto);
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
