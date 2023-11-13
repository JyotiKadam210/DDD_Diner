using BuberDiner.Application.Authentication.Command.Register;
using BuberDiner.Application.Authentication.Common;
using BuberDiner.Application.Authentication.Queries.Login;
using BuberDiner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiBaseController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender sender, IMapper mapper)
        {
            _mediator = sender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }
    }
}
