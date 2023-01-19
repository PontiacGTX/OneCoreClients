using System;
using System.Collections.Generic;
using System.Text;

namespace OneCoreClients.Shared.Responses
{
    public class ServerErrorResponse : Response
    {
        public override string Message { get; set; } = "Error";
        public override int StatusCode { get; set; } = 500;
        public IEnumerable<string> Validation { get; set; }
    }
}
