using BuberDiner.Application.Authentication.Common;
using BuberDiner.Application.Common.Interfaces.Authentication;
using BuberDiner.Application.Common.Interfaces.Persistance;
using BuberDiner.Domain.Common.Errors;
using BuberDiner.Domain.User;
using ErrorOr;
using MediatR;

namespace BuberDiner.Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(command.Email) is not null)
                return Errors.User.DuplicateEmail;

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
               user,
                token);
        }
    }    
}
