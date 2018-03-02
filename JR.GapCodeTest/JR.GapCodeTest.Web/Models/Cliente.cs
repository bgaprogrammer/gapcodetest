using System;
using System.Collections.Generic;
using JR.GapCodeTest.Web.Data.Repository;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Cliente : IEntity
    {
        public Cliente()
        {
            PolizaClientes = new HashSet<PolizaCliente>();
        }

        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PolizaCliente> PolizaClientes { get; set; }
    }
}