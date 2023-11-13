using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(code: "User.InvalidCred", description: "Invalid Credentials..");

        }
    }
}
