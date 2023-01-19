using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OneCoreClients.Shared.Helpers;
using OneCoreClients.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneCoreClients.API.Controllers
{
    public class HttpControllerBase : ControllerBase
    {
        protected ObjectResult OkResponse(object o)
          => Ok(new Response(o));
        protected ObjectResult ErrorResponse()
        => StatusCode(StatusCodes.Status500InternalServerError, Factory.GetResponse<ServerErrorResponse>(null,
                    500,
                    "Various internal unexpected errors happened",
                    false));
        protected ObjectResult BadRequestResponse(ModelStateDictionary ModelState)
             => BadRequest(Factory.GetResponse<ServerErrorResponse>(null, 400, "Bad Request", false,
                 ModelState.SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage))));

        protected ObjectResult BadRequestResponse(IEnumerable<string> validation, int statusCode = 400)
           => BadRequest(Factory.GetResponse<ServerErrorResponse>(null, statusCode, "Bad Request", false,
               validation.Select(e => e)));

        protected ObjectResult NotFoundResponse()
            => NotFound(Factory.GetResponse<ServerErrorResponse>(null, 404, "Not Found", false));
    }
}
