using AutoMapper;
using Brive.Core.DTOs;
using Brive.Core.DTOs.SucursalADTOs;
using Brive.Core.DTOs.SucursalBDTOs;
using Brive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brive.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //GET
            CreateMap<SucursalA, SucursalADTO>().ReverseMap();
            CreateMap<SucursalB, SucursalBDTO>().ReverseMap();

            //POST
            CreateMap<SucursalA, PostSucursalADTO>().ReverseMap();
            CreateMap<SucursalB, PostSucursalBDTO>().ReverseMap();
            CreateMap<SucursalA, PostSucursalGenericDTO>().ReverseMap();
            CreateMap<SucursalB, PostSucursalGenericDTO>().ReverseMap();

            //PUT
            CreateMap<SucursalA, PutSucursalADTO>().ReverseMap();
            CreateMap<SucursalB, PutSucursalBDTO>().ReverseMap();

            //DELETE 
            CreateMap<SucursalA, DeleteSucursalADTO>().ReverseMap();
            CreateMap<SucursalB, DeleteSucursalBDTO>().ReverseMap();
        }
    }
}
