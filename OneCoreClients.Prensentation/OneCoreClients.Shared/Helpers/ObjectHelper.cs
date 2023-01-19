using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCoreClients.Shared.Helpers
{
    public static class ObjectHelper
    {
        public static T CastJsonAs<T>(this object o)
        {
            return JsonConvert.DeserializeObject<T>(o.ToString(), Factory.GetCamelCaseOptions());
        }
    }
}
