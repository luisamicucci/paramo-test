using Application.Interfaces;
using Application.Queries.GetUsers;
using Application.UserTypeStrategyPattern;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AddNewUser
{
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, bool>
    {
        private readonly IMediator _mediator;
        public AddNewUserCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddNewUserCommandValidator();

            var results = validator.Validate(request);

            bool validationSucceeded = results.IsValid;

            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }

            IUserTypeStrategy stg = request.User.Type switch
            {
                UserType.NORMAL => new NormalTypeStg(),
                UserType.SUPER_USER => new SuperUserTypeStg(),
                UserType.PREMIUM => new PremiumTypeStg(),
                _ => throw new ValidationException("A valid user type is required"),
            };

            stg.Execute(request.User);

            if (await IsDuplicated(request.User))
            {
                throw new ValidationException("The current user already exists on data file");
            }

            return true;
        }

        public async Task<bool> IsDuplicated(User user)
        {
            var users = await _mediator.Send(new GetUsersQuery());

            if (users == null)
            {
                return false;
            }

            foreach (var usr in users)
            {
                if (user.IsDuplicated(usr))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
