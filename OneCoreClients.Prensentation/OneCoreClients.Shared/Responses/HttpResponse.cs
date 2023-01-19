using System;
using System.Collections.Generic;
using System.Text;

namespace OneCoreClients.Shared.Responses
{
    public class HttpResponse : Response
    {
        public IEnumerable<string> Validation { get; set; }
    }
}
