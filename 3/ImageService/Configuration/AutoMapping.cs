﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageService.Entities;
using ImageService.Models;

namespace ImageService.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ImageEntity, Image>();
        }
    }
}
