using System;
using System.Collections.Generic;

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

        public AgenciaDto Agencia { get; set; }
        public TipoCubrimientoDto TipoCubrimiento { get; set; }
        public TipoRiesgoDto TipoRiesgo { get; set; }
        public List<ClienteDto> Clientes { get; set; }
    }
}