using BuberDiner.Domain.Common.Models;
using BuberDiner.Domain.Common.ValueObjects;
using BuberDiner.Domain.Dinner.ValueObjects;
using BuberDiner.Domain.Host.ValueObjects;
using BuberDiner.Domain.Menu.Entities;
using BuberDiner.Domain.Menu.Events;
using BuberDiner.Domain.Menu.ValueObjects;
using BuberDiner.Domain.MenuReview.ValueObjects;

namespace BuberDiner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId,Guid>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _reviewIds = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRatings { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewId => _reviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId id,
            HostId hostId,
            string name,
            string description,
            AverageRating averageRatings,
            List<MenuSection> sections         
            ) : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRatings = averageRatings;
            HostId = hostId;
            _sections = sections;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
       // private Menu(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
       
        public static Menu Create(
            HostId hostId,
            string name,
            string description,            
            List<MenuSection>? sections = null)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                hostId,
                name, 
                description, 
                AverageRating.CreateNew(),
                sections ?? new()
               );

            menu.AddDomainEvent(new MenuCreated(menu));
            return menu;
        }
    }
}
