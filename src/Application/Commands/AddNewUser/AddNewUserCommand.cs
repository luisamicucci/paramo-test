using Domain.Entities;
using MediatR;

namespace Application.Commands.AddNewUser
{
    public class AddNewUserCommand : IRequest<bool>
    {
        public User User { get; set; }
    }
}
