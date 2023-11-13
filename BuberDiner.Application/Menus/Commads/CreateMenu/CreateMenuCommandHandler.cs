using BuberDiner.Application.Common.Interfaces.Persistance;
using BuberDiner.Domain.Dinner.ValueObjects;
using BuberDiner.Domain.Host.ValueObjects;
using BuberDiner.Domain.Menu;
using BuberDiner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.Menus.Commads.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;
        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var menu = Menu.Create(
                HostId.Create(request.HostId),
                request.Name, 
                request.Description,
                request.Sections.ConvertAll(menuSection => MenuSection.Create(
                    menuSection.Name, 
                menuSection.Description, 
                menuSection.Items.ConvertAll(i => MenuItem.Create(i.Name, i.Description))))
                );
            _menuRepository.Add(menu);

            return menu;
        }
    }
}
