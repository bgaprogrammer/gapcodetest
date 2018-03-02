using System;
using System.Collections.Generic;
using JR.GapCodeTest.Web.Data.Repository;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Ciudad : IEntity
    {
        public Ciudad()
        {
            Agencias = new HashSet<Agencia>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Agencia> Agencias { get; set; }
    }
}
