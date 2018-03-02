using System;
using JR.GapCodeTest.Web.Models;

namespace JR.GapCodeTest.Web.Data.Repository.Implementation
{
    public class TipoRiesgoRepository : GenericRepository<Tiporiesgo>, ITipoRiesgoRepository
    {
        public TipoRiesgoRepository(GapCodeTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}