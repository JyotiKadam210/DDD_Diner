using BuberDiner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; }
        private MenuReviewId(Guid value)
        {
            Value = value;  
        }

        public static MenuReviewId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
