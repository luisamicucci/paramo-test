using Application.Commands.AddNewUser;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserModel model)
    {
        var user = new User();

        user += model; //Insted of using automapper

        await _mediator.Send(new AddNewUserCommand() { User = user });
        return Ok("User created");
    }    
}