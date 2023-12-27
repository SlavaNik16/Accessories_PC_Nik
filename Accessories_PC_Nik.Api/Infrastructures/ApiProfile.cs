﻿using Accessories_PC_Nik.Api.Enums;
using Accessories_PC_Nik.Api.Models;
using Accessories_PC_Nik.Api.ModelsRequest.AccessKey;
using Accessories_PC_Nik.Api.ModelsRequest.Client;
using Accessories_PC_Nik.Api.ModelsRequest.Component;
using Accessories_PC_Nik.Api.ModelsRequest.Delivery;
using Accessories_PC_Nik.Api.ModelsRequest.Order;
using Accessories_PC_Nik.Api.ModelsRequest.Service;
using Accessories_PC_Nik.Api.ModelsRequest.Worker;
using Accessories_PC_Nik.Services.Contracts.Enums;
using Accessories_PC_Nik.Services.Contracts.ModelRequest;
using Accessories_PC_Nik.Services.Contracts.Models;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Microsoft.OpenApi.Extensions;

namespace Accessories_PC_Nik.Api.Infrastructures
{
    /// <summary>
    /// Профиль маппера Api
    /// </summary>
    public class ApiProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApiProfile"/>
        /// </summary>
        public ApiProfile()
        {
            CreateMap<AccessLevelTypesModel, AccessLevelTypesResponce>()
               .ConvertUsingEnumMapping(opt => opt.MapByName())
               .ReverseMap();
            CreateMap<DocumentTypesModel, DocumentTypesResponce>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<MaterialTypeModel, MaterialTypeResponce>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<TypeComponentsModel, TypeComponentsResponce>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<AccessKeyModel, AccessKeyResponse>(MemberList.Destination)
                 .ForMember(x => x.Types, opt => opt.MapFrom(y => y.Types.GetDisplayName()));
            CreateMap<CreateAccessKeyRequest, AccessKeyRequestModel>(MemberList.Destination);

            CreateMap<ClientModel, ClientsResponse>(MemberList.Destination)
                 .ForMember(x => x.FI0,
                    opt => opt.MapFrom(y => $"{y.Surname} {y.Name} {y.Patronymic ?? string.Empty}"))
                .ForMember(x => x.Phone,
                    opt => opt.MapFrom(y => y.Phone));
            CreateMap<CreateClientRequest, ClientRequestModel>(MemberList.Destination);
            CreateMap<EditClientRequest, ClientRequestModel>(MemberList.Destination);

            CreateMap<ComponentModel, ComponentsResponse>(MemberList.Destination)
                .ForMember(x => x.MaterialType, opt => opt.MapFrom(y => y.MaterialType.GetDisplayName()))
                .ForMember(x => x.TypeComponents, opt => opt.MapFrom(y => y.TypeComponents.GetDisplayName()));
            CreateMap<CreateComponentRequest, ComponentRequestModel>(MemberList.Destination);
            CreateMap<EditComponentRequest, ComponentRequestModel>(MemberList.Destination);

            CreateMap<DeliveryModel, DeliveryResponse>(MemberList.Destination);
            CreateMap<CreateDeliveryRequest, DeliveryRequestModel>(MemberList.Destination);
            CreateMap<EditDeliveryRequest, DeliveryRequestModel>(MemberList.Destination);

            CreateMap<OrderModel, OrderResponse>(MemberList.Destination)
                .ForMember(x => x.NameService,
                    opt => opt.MapFrom(y => y.Services != null ? y.Services.Name : string.Empty))
                .ForMember(x => x.TypeComponents,
                    opt => opt.MapFrom(y => y.Components != null ? y.Components.TypeComponents.GetDisplayName() : string.Empty))
                .ForMember(x => x.FIO,
                    opt => opt.MapFrom(y => $"{y.Clients.Surname} {y.Clients.Name} {y.Clients.Patronymic ?? string.Empty}"))
                .ForMember(x => x.Phone,
                    opt => opt.MapFrom(y => y.Clients.Phone));
            CreateMap<CreateOrderRequest, OrderRequestModel>(MemberList.Destination);
            CreateMap<EditOrderRequest, OrderRequestModel>(MemberList.Destination);

            CreateMap<ServiceModel, ServicesResponse>(MemberList.Destination);
            CreateMap<CreateServiceRequest, ServiceRequestModel>(MemberList.Destination);
            CreateMap<EditServiceRequest, ServiceRequestModel>(MemberList.Destination);

            CreateMap<WorkerModel, WorkersResponse>(MemberList.Destination)
                .ForMember(x => x.FIO,
                    opt => opt.MapFrom(y => $"{y.Clients.Surname} {y.Clients.Name} {y.Clients.Patronymic ?? string.Empty}"))
                .ForMember(x => x.Phone,
                    opt => opt.MapFrom(y => y.Clients.Phone));

            CreateMap<CreateWorkerRequest, WorkerRequestModel>(MemberList.Destination);
            CreateMap<EditWorkerRequest, WorkerRequestModel>(MemberList.Destination);

        }
    }
}
