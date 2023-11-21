﻿using Accessories_PC_Nik.Context.Contracts.Enums;
using Accessories_PC_Nik.Context.Contracts.Models;
using Accessories_PC_Nik.Services.Contracts.Enums;
using Accessories_PC_Nik.Services.Contracts.Models;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;

namespace Accessories_PC_Nik.Services.Automappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile() 
        {
            CreateMap<AccessLevelTypes, AccessLevelTypesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<DocumentTypes, DocumentTypesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<MaterialType, MaterialTypeModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<TypeComponents, TypeComponentsModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<AccessKey, AccessKeyModel>(MemberList.Destination);

            CreateMap<Clients, ClientsModel>(MemberList.Destination);

            CreateMap<Components, ComponentsModel>(MemberList.Destination);

            CreateMap<Delivery, DeliveryModel>(MemberList.Destination);

            CreateMap<Order, OrderModel>(MemberList.Destination)
                .ForMember(pref => pref.ServicesModel, next => next.Ignore())
                .ForMember(pref => pref.ComponentsModel, next => next.Ignore())
                .ForMember(pref => pref.DeliveryModel, next => next.Ignore());

            CreateMap<Context.Contracts.Models.Services, ServicesModel>(MemberList.Destination);

            CreateMap<Workers, WorkersModel>(MemberList.Destination)
                .ForMember(pref => pref.ClientsModel, next => next.Ignore());
        }
    }
}