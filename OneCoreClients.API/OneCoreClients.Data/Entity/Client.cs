using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneCoreClients.Data.Entity
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string CP { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }

    }
}
