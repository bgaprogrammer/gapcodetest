using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Poliza = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }

        public ICollection<Poliza> Poliza { get; set; }
    }
}
