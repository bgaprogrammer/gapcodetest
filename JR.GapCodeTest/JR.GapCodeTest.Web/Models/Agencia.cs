using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JR.GapCodeTest.Web.Data.Repository;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Agencia : IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CiudadId { get; set; }

        [ForeignKey("CiudadId")]
        public virtual Ciudad Ciudad { get; set; }
    }
}