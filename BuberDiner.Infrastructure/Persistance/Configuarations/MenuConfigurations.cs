using BuberDiner.Domain.Host.ValueObjects;
using BuberDiner.Domain.Menu;
using BuberDiner.Domain.Menu.Entities;
using BuberDiner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDiner.Infrastructure.Persistance.Configuarations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenuTable(builder);
            ConfigureSectionMenuTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewsIdsTable(builder);
        }

        private void ConfigureMenuReviewsIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, di =>
            {
                di.ToTable("MenuDinnerIds");
                di.WithOwner().HasForeignKey("MenuId");
                di.HasKey("Id");

                di.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds));
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewId, ri =>
            {
                ri.ToTable("MenuReviewIds");
                ri.WithOwner().HasForeignKey("MenuId");
                ri.HasKey("Id");

                ri.Property(d => d.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewId));
            builder.Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

        }

        private static void ConfigureSectionMenuTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey("Id", "MenuId");

                sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuSectionId.Create(value));
                sb.Property(s => s.Name)
                .HasMaxLength(100);

                sb.Property(s => s.Description)
                .HasMaxLength(100);

                sb.OwnsMany(m => m.Items, ib =>
                 {
                     ib.ToTable("MenuItem");
                     ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                     ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                     ib.Property(s => s.Id)
                     .HasColumnName("MenuItemId")
                     .ValueGeneratedNever()
                     .HasConversion(
                     id => id.Value,
                     value => MenuItemId.Create(value));

                     ib.Property(s => s.Name)
                     .HasMaxLength(100);

                     ib.Property(s => s.Description)
                     .HasMaxLength(100);
                 });

                sb.Navigation(s => s.Items).Metadata.SetField("_menuItems");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    

        private static void ConfigureMenuTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);
            builder.Property(m => m.Description)
                .HasMaxLength(100);

            builder.OwnsOne(m => m.AverageRatings);

            builder.Property(m => m.HostId)
                .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
        }
    }
}
