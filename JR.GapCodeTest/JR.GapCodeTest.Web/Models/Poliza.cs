using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Poliza
    {
        public Poliza()
        {
            PolizaClientes = new HashSet<PolizaCliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime InicioVigencia { get; set; }
        public int CoberturaMeses { get; set; }
        public decimal Precio { get; set; }
        public int PorcentajeCubrimiento { get; set; }
        public int AgenciaId { get; set; }
        public int TipoRiesgoId { get; set; }
        public int TipoCubrimientoId { get; set; }

        [ForeignKey("AgenciaId")]
        public Agencia Agencia { get; set; }

        [ForeignKey("TipoCubrimientoId")]
        public Tipocubrimiento TipoCubrimiento { get; set; }

        [ForeignKey("TipoRiesgoId")]
        public Tiporiesgo TipoRiesgo { get; set; }

        public ICollection<PolizaCliente> PolizaClientes { get; set; }
    }
}