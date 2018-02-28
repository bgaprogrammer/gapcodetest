using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Tiporiesgo
    {
        public Tiporiesgo()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MaxPorcentajeCubrimiento { get; set; }

        public ICollection<Poliza> Polizas { get; set; }
    }
}