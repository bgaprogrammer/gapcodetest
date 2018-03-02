using System;
using JR.GapCodeTest.Web.Models;

namespace JR.GapCodeTest.Web.Data.Repository.Implementation
{
    public class TipoCubrimientoRepository : GenericRepository<Tipocubrimiento>, ITipoCubrimientoRepository
    {
        public TipoCubrimientoRepository(GapCodeTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}