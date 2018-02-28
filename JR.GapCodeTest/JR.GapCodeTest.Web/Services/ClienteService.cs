using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JR.GapCodeTest.Web.Services
{
    public class ClienteService : ICliente
    {
        private readonly GapCodeTestDbContext _dbcontext;
        private readonly IMapper _mapper;
        
        public ClienteService(GapCodeTestDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ClienteDto>> ObtenerClientes()
        {
            var result = await _dbcontext.Cliente.ToListAsync();

            return _mapper.Map<List<ClienteDto>>(result);
        }
    }
}