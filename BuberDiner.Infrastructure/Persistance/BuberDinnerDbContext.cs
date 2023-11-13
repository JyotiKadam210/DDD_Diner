using BuberDiner.Domain.Common.Models;
using BuberDiner.Domain.Menu;
using BuberDiner.Infrastructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Infrastructure.Persistance
{
    public class BuberDinnerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _interceptors;
        public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options,
            PublishDomainEventsInterceptor interceptors)
            : base(options)
        {
            _interceptors = interceptors;
        }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvents>>()
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptors);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
