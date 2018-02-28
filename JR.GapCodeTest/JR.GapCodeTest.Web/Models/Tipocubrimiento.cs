using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Tipocubrimiento
    {
        public Tipocubrimiento()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Poliza> Polizas { get; set; }
    }
}
