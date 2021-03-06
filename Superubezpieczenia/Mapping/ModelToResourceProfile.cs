﻿using AutoMapper;
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
            CreateMap<ParkingPlaceDTO, ParkingPlace>();

            CreateMap<TypeInsurance, TypeInsuranceVM>();
            CreateMap<TypeInsuranceDTO, TypeInsurance>();

            CreateMap<TypeFuel, TypeFuelVM>();
            CreateMap<TypeFuelDTO, TypeFuel>();

            CreateMap<TypeOwner, TypeOwnerVM>();
            CreateMap<TypeOwnerDTO, TypeOwner>();

            CreateMap<Insurance, InsuranceVM>();
            CreateMap<InsuranceDTO, Insurance>();

            CreateMap<PolicyDetails, PolicyDetailsVM>();
            CreateMap<PolicyDetailsDTO, PolicyDetails>();
        }
    }
}
