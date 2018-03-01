using System;
namespace JR.GapCodeTest.Web.Models.Dto
{
    public class AgenciaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public CiudadDto Ciudad { get; set; }
    }
}