using BuberDiner.Domain.Host.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.UnitTests.Menus.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId hostd = HostId.Create("Host_ID");
        }
    }
}
