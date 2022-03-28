using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Validators
{
    public class CreateCommentResourceValidator:AbstractValidator<CreateComentDTO>
    {
        public CreateCommentResourceValidator()
        {
            RuleFor(m => m.CommentText).MaximumLength(50).NotEmpty();
            RuleFor(m => m.CommentText).MaximumLength(300).NotEmpty();
        }
    }
}
