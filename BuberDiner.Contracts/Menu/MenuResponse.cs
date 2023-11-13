using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Contracts.Menu
{
    public record MenuResponse(
        Guid Id,
        string Name,
        string Description,
        float? AverageRating,
        List<MenuSectionResponse> Sections,
        string HostId,
        List<string> DinnerIds,
        List<string> MenuReviewIds,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record MenuSectionResponse(
       Guid Id,
       string Name,
       string Description,
       List<MenuItemResponse> Items);

    public record MenuItemResponse(
       Guid Id,
       string Name,
       string Description);

}
