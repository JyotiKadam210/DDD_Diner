using BuberDiner.Domain.Common.Models;
using BuberDiner.Domain.Menu.ValueObjects;

namespace BuberDiner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _menuItems;
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyList<MenuItem> Items => _menuItems.AsReadOnly();

        private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> menuItems) : base(id)
        {
            Name = name;
            Description = description;
            _menuItems = menuItems;
        }

        public static MenuSection Create(string name, string description , List<MenuItem> menuItems)
        {
            return new MenuSection(MenuSectionId.CreateUnique(), name, description, menuItems);
        }
    }
}