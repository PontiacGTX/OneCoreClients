using System;
using System.Collections.Generic;
using System.Text;

namespace OneCoreClients.Data.Models
{

    

    public class ServicesEndpoints
    {
        public string BaseServicesUrl { get; set; }
        public string ExistClientId { get; set; }
        public string AddClient { get; set; }
        public string UpdateClient { get; set; }
        public string GetAllClient { get; set; }
        public string GetClientById { get; set; }
        public string DeleteClientById { get; set; }
    }
}
