using BuberDiner.Domain.Common.Models;

namespace BuberDiner.Domain.Common.ValueObjects
{
    public class Rating : ValueObject
    {
        public double Value { get; internal set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return new object[] { Value };
        }
    }
}