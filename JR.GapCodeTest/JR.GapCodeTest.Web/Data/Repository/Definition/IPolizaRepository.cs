using System;
using System.Threading.Tasks;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Data.Repository
{
    public interface IPolizaRepository : IGenericRepository<Poliza>
    {
        Task UpdateWithRelated(PolizaDto p);
        Task DeleteWithRelated(int id);
    }
}