using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JR.GapCodeTest.Web.Services
{
    public class CiudadService : ICiudad
    {
        private readonly GapCodeTestDbContext _dbcontext;
        private readonly IMapper _mapper;
        
        public CiudadService(GapCodeTestDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CiudadDto>> ObtenerCiudades()
        {
            var result = await _dbcontext.Ciudad.ToListAsync();
            
            return _mapper.Map<List<CiudadDto>>(result);
        }
    }
}