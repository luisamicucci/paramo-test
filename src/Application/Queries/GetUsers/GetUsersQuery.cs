using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<User>>
    {
    }
}
