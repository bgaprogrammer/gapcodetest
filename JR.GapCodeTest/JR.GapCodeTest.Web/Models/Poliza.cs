using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JR.GapCodeTest.Web.Data.Repository;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Poliza : IEntity
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
        public virtual Agencia Agencia { get; set; }

        [ForeignKey("TipoCubrimientoId")]
        public virtual Tipocubrimiento TipoCubrimiento { get; set; }

        [ForeignKey("TipoRiesgoId")]
        public virtual Tiporiesgo TipoRiesgo { get; set; }

        public virtual ICollection<PolizaCliente> PolizaClientes { get; set; }
    }
}