
using Core.Application.Requests;
using FluentValidation;

namespace Backend.Core.Application.Validation;

public class CreatePostValidation: AbstractValidator<CreatePostRequest>
{
    public CreatePostValidation()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Post content is required.")
            .MaximumLength(777)
            .WithMessage("Post content must be between 1 and 777 characters.");    
    }
}