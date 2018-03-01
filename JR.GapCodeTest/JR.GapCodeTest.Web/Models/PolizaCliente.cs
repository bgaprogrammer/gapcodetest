using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JR.GapCodeTest.Web.Models
{
    public class PolizaCliente
    {
        public int PolizaId { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("PolizaId")]
        public Poliza Poliza { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}