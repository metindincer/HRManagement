using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Validators
{
    public class UpdatePermissionResourceValidator : AbstractValidator<UpdatePermissionDTO>
    {
        public UpdatePermissionResourceValidator()
        {
            RuleFor(a => a.PermissionName).NotEmpty().MaximumLength(100);
            RuleFor(a => a.PermissionTypeId).NotEmpty();
            RuleFor(a => a.PermissionType).NotEmpty();
            RuleFor(a => a.PermissionStartDate).NotEmpty();
            RuleFor(a => a.PermissionEndDate).NotEmpty(); ;
        }
    }
}
