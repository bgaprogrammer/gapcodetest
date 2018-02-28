using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Poliza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime InicioVigencia { get; set; }
        public int CoberturaMeses { get; set; }
        public decimal Precio { get; set; }
        public int IdTipoCubrimiento { get; set; }
        public int IdTipoRiesgo { get; set; }

        public Tipocubrimiento TipoCubrimiento { get; set; }
        public Tiporiesgo TipoRiesgo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
