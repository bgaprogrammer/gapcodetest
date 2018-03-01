using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Agencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CiudadId { get; set; }

        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }
    }
}