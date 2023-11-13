using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
        where TId : ValueObject
    {
        private readonly List<IDomainEvents> _domainEvents= new();
        public TId Id { get; protected set; }

        public IReadOnlyList<IDomainEvents> DomainEvents  => _domainEvents.AsReadOnly(); 
        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals(other);
        }

        public void AddDomainEvent(IDomainEvents domainEvents) 
        { 
            _domainEvents.Add(domainEvents);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
