﻿using BuberDiner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Menu.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;  
        }

        public static MenuSectionId Create(Guid value)
        {
           return new MenuSectionId(value);
        }

        public static MenuSectionId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
           yield return Value;
        }
    }
}
