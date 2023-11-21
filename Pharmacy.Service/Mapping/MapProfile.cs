using AutoMapper;
using Pharmacy.Core.DTOs;
using Pharmacy.Core.Models;

namespace Pharmacy.Service.Mapping
{
    public class MapProfile : Profile 
    {
        public MapProfile()
        {
            CreateMap<Suplier, SuplierDto>().ReverseMap();
            CreateMap<Medicine, MedicineDto>().ReverseMap();
            CreateMap<SuplierUpdateDto, Suplier>();
            CreateMap<MedicineUpdateDto, Medicine>();
            CreateMap<Medicine, MedicineWithSuplierDto>();
            CreateMap<Suplier, SuplierWithMedicinesDto>();
            CreateMap<MedicineCreateDto, Medicine>();
            CreateMap<SuplierCreateDto, Suplier>();
        }
    }
}
