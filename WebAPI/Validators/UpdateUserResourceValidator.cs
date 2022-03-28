using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Validators
{
    public class UpdateUserResourceValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserResourceValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Surname).NotEmpty();
            //RuleFor(a => a.DateOfBirth).NotEmpty();
            //RuleFor(a => a.JobStartDate).NotEmpty();
            //RuleFor(a => a.About).NotEmpty();
            //RuleFor(a => a.JobTitle).NotEmpty();            
        }
    }
}
