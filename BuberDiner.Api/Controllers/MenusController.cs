using BuberDiner.Application.Authentication.Common;
using BuberDiner.Application.Menus.Commads.CreateMenu;
using BuberDiner.Contracts.Menu;
using BuberDiner.Domain.Menu;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        public MenusController(IMapper mapper, ISender mediator) 
        { 
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public  async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            ErrorOr<Menu> menuResult = await _mediator.Send(command);

            return menuResult.Match(
                authResult => Ok(_mapper.Map<MenuResponse>(menuResult)),
                errors => Problem(errors)
                );
           
        }

    }
}
