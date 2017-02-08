using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Enums
{
    public enum ResponseStatusCode
    {
        Continue = 100,
        OK = 200,
        BadRequest = 400,
        Forbiden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
    }
}
