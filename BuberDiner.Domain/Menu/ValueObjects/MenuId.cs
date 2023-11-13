using BuberDiner.Domain.Common.Models;

namespace BuberDiner.Domain.Menu.ValueObjects
{
    public class MenuId : AggregateRootId<Guid>
    {       
        public override Guid Value { get; protected set; }

        private MenuId(Guid value)
        {
            Value = value;  
        }

        public static MenuId Create(Guid value) 
        { 
            return new MenuId(value);
        }

        public static MenuId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
