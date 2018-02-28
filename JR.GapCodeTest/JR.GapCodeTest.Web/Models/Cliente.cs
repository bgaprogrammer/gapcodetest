using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }

        public ICollection<Poliza> Polizas { get; set; }
    }
}