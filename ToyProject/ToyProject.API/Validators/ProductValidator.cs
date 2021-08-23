using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toy.Services.Dto.Input;

namespace ToyProject.API.Validators
{
    public class ProductValidator : AbstractValidator<ProductInsertDto>
    {
        public ProductValidator()
        {
            //RuleFor(x => x.AgeRestriction)
            //    .Must(BeAgeValid).WithMessage("Invalid input for age restriction (must be between 1-5)");
        }

        //protected bool BeAgeValid (int ageRestriction)
        //{
        //    if (ageRestriction >= 1 && ageRestriction <= 5)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

    }
}
