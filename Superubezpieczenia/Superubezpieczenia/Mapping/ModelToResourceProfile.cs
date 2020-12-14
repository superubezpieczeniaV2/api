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
        }
    }
}