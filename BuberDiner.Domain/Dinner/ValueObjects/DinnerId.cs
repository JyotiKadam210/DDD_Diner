using BuberDiner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Dinner.ValueObjects
{
    public class DinnerId : ValueObject
    {
        public Guid Value { get; }
        private DinnerId(Guid value)
        {
            Value = value;  
        }

        public static DinnerId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
