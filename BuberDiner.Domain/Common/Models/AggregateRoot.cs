using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Common.Models
{
    public abstract class AggregateRoot<TId, TIdtype> : Entity<TId>
        where TId : AggregateRootId<TIdtype>
    {
        public new AggregateRootId<TIdtype> Id { get; protected set; }

#pragma warning disable CS8618
        //protected AggregateRoot()
        //{ }
#pragma warning restore CS8618
        protected AggregateRoot(TId id)
        {
            Id = id;
        }
    }
}
