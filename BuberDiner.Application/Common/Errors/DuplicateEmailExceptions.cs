using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.Common.Errors
{
    public class DuplicateEmailExceptions : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string EoorMessage => "Email alreday exists";
    }
}
