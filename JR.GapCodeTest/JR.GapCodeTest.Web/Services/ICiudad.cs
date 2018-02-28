using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services
{
    public interface ICiudad
    {
        Task<List<CiudadDto>> ObtenerCiudades();
    }
}