using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; }
        public int Expiryminutes { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
    }
}
 