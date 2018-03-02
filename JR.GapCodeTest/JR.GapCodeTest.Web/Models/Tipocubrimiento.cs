using System;
using System.Collections.Generic;
using JR.GapCodeTest.Web.Data.Repository;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Tipocubrimiento : IEntity
    {
        public Tipocubrimiento()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
