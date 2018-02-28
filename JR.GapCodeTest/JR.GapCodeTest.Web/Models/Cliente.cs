using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            PolizaClientes = new HashSet<PolizaCliente>();
        }

        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }

        public ICollection<PolizaCliente> PolizaClientes { get; set; }
    }
}