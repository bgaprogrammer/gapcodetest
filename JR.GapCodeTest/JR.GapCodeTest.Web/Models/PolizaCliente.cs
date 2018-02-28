using System;
namespace JR.GapCodeTest.Web.Models
{
    public class PolizaCliente
    {
        public int PolizaId { get; set; }
        public int ClienteId { get; set; }

        public Poliza Poliza { get; set; }
        public Cliente Cliente { get; set; }
    }
}