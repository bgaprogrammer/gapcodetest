using System;
using JR.GapCodeTest.Web.Models;

namespace JR.GapCodeTest.Web.Data.Repository.Implementation
{
    public class AgenciaRepository : GenericRepository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(GapCodeTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}