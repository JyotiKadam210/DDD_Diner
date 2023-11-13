using BuberDiner.Domain.Common.Models;
using BuberDiner.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Host.ValueObjects
{
    public class HostId : AggregateRootId<string>
    {
        public override string Value { get; protected set; }

        private HostId(string value)
        {
            Value = value;  
        }

        public static HostId CreateUnique() => new (Guid.NewGuid().ToString());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }

        public static HostId Create(string hostId)
        {
            return new HostId(hostId);
        }
    }
}
