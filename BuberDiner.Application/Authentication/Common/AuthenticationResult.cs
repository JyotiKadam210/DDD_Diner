using BuberDiner.Domain.User;

namespace BuberDiner.Application.Authentication.Common
{
    public record AuthenticationResult
    (
       User User,
        string Token
     );
}