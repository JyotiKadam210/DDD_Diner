using BuberDiner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDiner.Application.Authentication.Command.Register
{
    public record RegisterCommand(string FirstName,
                                  string LastName,
                                  string Email,
                                  string Password) : IRequest<ErrorOr<AuthenticationResult>>;
   }
