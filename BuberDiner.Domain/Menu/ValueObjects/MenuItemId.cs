using BuberDiner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Menu.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        public Guid Value { get; }
        private MenuItemId(Guid value)
        {
            Value = value;  
        }

        public static MenuItemId Create(Guid value)
        {
            return new MenuItemId(value);
        }

        public static MenuItemId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
