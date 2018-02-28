using System;

namespace JR.GapCodeTest.Web.Models.Dto
{
    public class TipoRiesgoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MaxPorcentajeCubrimiento { get; set; }
    }
}