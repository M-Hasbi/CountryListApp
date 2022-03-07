﻿using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CountryBorder, CountryBorderDto>().ReverseMap();
            CreateMap<Country, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<CountryBorderUpdateDto, CountryBorder>();
            CreateMap<CountryBorder, CountryBorderWithCountryDto>();
            CreateMap<Country, CountryWithCountryBordersDto>();
        }
    }
}
