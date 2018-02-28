using System;
using System.Collections.Generic;

namespace JR.GapCodeTest.Web.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Agencia = new HashSet<Agencia>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Agencia> Agencia { get; set; }
    }
}
