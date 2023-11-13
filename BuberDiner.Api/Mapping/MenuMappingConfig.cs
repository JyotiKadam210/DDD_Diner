using BuberDiner.Application.Menus.Commads.CreateMenu;
using BuberDiner.Contracts.Menu;
using BuberDiner.Domain.Menu;
using Mapster;
namespace BuberDiner.Api.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.hostId)
                .Map(dest => dest, src => src.request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AverageRating, src => src.AverageRatings.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewId.Select(r => r.Value));


            config.NewConfig<BuberDiner.Domain.Menu.Entities.MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<BuberDiner.Domain.Menu.Entities.MenuItem, MenuItemResponse>()
               .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
