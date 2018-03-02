using System;
using JR.GapCodeTest.Web.Models;

namespace JR.GapCodeTest.Web.Data.Repository.Implementation
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GapCodeTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}