using Application.Commands.AddNewUser;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserTests
    {
        [Fact]
        public async Task Success_Test()
        {
            var mediator = new Mock<IMediator>();

            var handler = new AddNewUserCommandHandler(mediator.Object);

            var result = await handler.Handle(new AddNewUserCommand
            {
                User = new User
                { 
                    Address = "Av. Siempre Viva 100", 
                    Email = "luisamicucci2011@gmail.com", 
                    Money = 100, 
                    Name = "Luis Amicucci", 
                    Phone = "+5493512443842", 
                    Type = UserType.NORMAL 
                }
            }, CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task InvalidEmail_Test()
        {
            var mediator = new Mock<IMediator>();

            var handler = new AddNewUserCommandHandler(mediator.Object);

            var ex = await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(new AddNewUserCommand
            {
                User = new User
                {
                    Address = "Av. Siempre Viva 100",
                    Email = "luisamicucci2011gmail.com",
                    Money = 100,
                    Name = "Luis Amicucci",
                    Phone = "+5493512443842",
                    Type = UserType.NORMAL
                }
            }, CancellationToken.None));

            Assert.NotNull(ex);
            Assert.Contains("A valid email is required", ex.Message);
        }
    }
}
