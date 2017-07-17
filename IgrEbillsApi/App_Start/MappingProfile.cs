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

            Mapper.CreateMap<aspnetuser, UserDTO>();
            Mapper.CreateMap<UserDTO, aspnetuser>();

            Mapper.CreateMap<tin, TinDTO>();
            Mapper.CreateMap<TinDTO, tin>();

            Mapper.CreateMap<CollectionDTO, pos_collection>();
            Mapper.CreateMap<pos_collection,CollectionDTO>();

            Mapper.CreateMap<RemittanceDTO, remittance>();
            Mapper.CreateMap<remittance, RemittanceDTO>();

            Mapper.CreateMap<InvoceDTO, invoice>();
            Mapper.CreateMap<invoice, InvoceDTO>();
        }
    }
}