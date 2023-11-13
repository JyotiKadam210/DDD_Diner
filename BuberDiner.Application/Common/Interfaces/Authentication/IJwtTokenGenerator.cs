using BuberDiner.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
