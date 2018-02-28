using System;
namespace JR.GapCodeTest.Web.Models.Dto
{
    public class PolizaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime InicioVigencia { get; set; }
        public int CoberturaMeses { get; set; }
        public decimal Precio { get; set; }
        public int PorcentajeCubrimiento { get; set; }
        public int IdTipoCubrimiento { get; set; }
        public int IdTipoRiesgo { get; set; }
        public int IdCliente { get; set; }
    }
}