using AutoMapper;
using IgrEbillsApi.DTOs;
using IgrEbillsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<pos,PosDTO>();
            Mapper.CreateMap<PosDTO,pos>();
        }
    }
}