using FluentValidation;

namespace Application.Commands.AddNewUser
{
    public class AddNewUserCommandValidator : AbstractValidator<AddNewUserCommand>
    {
        public AddNewUserCommandValidator()
        {
            RuleFor(x => x.User.Email).NotEmpty().WithMessage("The email is required").EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.User.Address).NotEmpty().WithMessage("The address is required");
            RuleFor(x => x.User.Name).NotEmpty().WithMessage("The name is required");
            RuleFor(x => x.User.Phone).NotEmpty().WithMessage("The Phone is required");
        }
    }
}
