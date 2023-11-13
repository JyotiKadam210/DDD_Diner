using BuberDiner.Application.Authentication.Common;
using BuberDiner.Application.Common.Interfaces.Authentication;
using BuberDiner.Application.Common.Interfaces.Persistance;
using BuberDiner.Domain.Common.Errors;
using BuberDiner.Domain.User;
using ErrorOr;
using MediatR;

namespace BuberDiner.Application.Authentication.Queries.Login
{
    internal class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
