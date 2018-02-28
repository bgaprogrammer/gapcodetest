using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Poliza
    {
        public Poliza()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime InicioVigencia { get; set; }
        public int CoberturaMeses { get; set; }
        public decimal Precio { get; set; }
        public int PorcentajeCubrimiento { get; set; }

        public Tipocubrimiento TipoCubrimiento { get; set; }
        public Tiporiesgo TipoRiesgo { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}