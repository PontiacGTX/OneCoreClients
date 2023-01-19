using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCoreClients.Shared.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationSection GetSection<T>(this IConfiguration configuration,string section)
        {
            return null;
        }
    }
}
