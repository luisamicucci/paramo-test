using Domain.Entities;
using Domain.Enums;
using Infrastructure.Helpers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        public const string path = "/Persistence/Data/Users.txt";
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = new List<User>();
            var reader = FileHelper.ReadFromFile(path);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    Type = (UserType)int.Parse(line.Split(',')[4].ToString()),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                result.Add(user);
            }
            reader.Close();

            return result;
        }
    }
}
