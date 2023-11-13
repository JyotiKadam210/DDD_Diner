using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Contracts.Authentication
{
    public record RegisterRequest ( string FirstName, string LastName, string Email, string Password);
   
}
