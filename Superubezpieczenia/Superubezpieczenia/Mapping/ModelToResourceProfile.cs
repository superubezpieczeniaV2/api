using AutoMapper;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Mark, MarkVM>();
            CreateMap<MarkDTO, Mark>();

            CreateMap<TypeOwner, TypeOwnerVM>();
            CreateMap<TypeOwnerDTO, TypeOwner>();

            CreateMap<Model, ModelVM>();
            CreateMap<ModelDTO, Model>();

            CreateMap<EnginePower, EnginePowerVM>();
            CreateMap<EnginePowerDTO, EnginePower>();

            CreateMap<MethodUse, MethodUseVM>();
            CreateMap<MethodUseDTO, MethodUse>();

            CreateMap<ParkingPlace, ParkingPlaceVM>();
            CreateMap<ParkingPlaceDTO, ParkingPlaceVM>();

            CreateMap<PriceList, PriceListVM>();
            CreateMap<PriceListDTO, PriceList>();

            CreateMap<TypeFuel, TypeFuelVM>();
            CreateMap<TypeFuelDTO, TypeFuel>();

            CreateMap<TypeOwner, TypeOwnerVM>();
            CreateMap<TypeOwnerDTO, TypeOwner>();
        }
    }
}
