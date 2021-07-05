using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toy.Services.Dto.Input;

namespace ToyProject.API.Validators
{
    public class ContactValidator : AbstractValidator<ContactInsertDto>
    {
        public ContactValidator()
        {
            
        }

    }
}
