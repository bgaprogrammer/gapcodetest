using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JR.GapCodeTest.Web.Services
{
    public class AgenciaService : IAgencia
    {
        private readonly GapCodeTestDbContext _dbcontext;
        private readonly IMapper _mapper;
        
        public AgenciaService(GapCodeTestDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<AgenciaDto>> ObtenerAgencias()
        {
            var result = await _dbcontext.Agencia.ToListAsync();

            return _mapper.Map<List<AgenciaDto>>(result);
        }
    }
}