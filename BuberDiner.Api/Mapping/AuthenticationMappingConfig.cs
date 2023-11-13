using BuberDiner.Application.Authentication.Command.Register;
using BuberDiner.Application.Authentication.Common;
using BuberDiner.Application.Authentication.Queries.Login;
using BuberDiner.Contracts.Authentication;
using Mapster;

namespace BuberDiner.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
            
        }
    }
}
