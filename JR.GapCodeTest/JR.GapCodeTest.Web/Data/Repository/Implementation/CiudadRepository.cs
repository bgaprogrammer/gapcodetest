using System;
using JR.GapCodeTest.Web.Models;

namespace JR.GapCodeTest.Web.Data.Repository.Implementation
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
        public CiudadRepository(GapCodeTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}