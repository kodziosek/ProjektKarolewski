using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;

namespace ProjektKarolewski
{
    public class DeviceMappingProfile : Profile
    {
        public DeviceMappingProfile()
        {
            CreateMap<Device, DeviceDto>()
                .ForMember(m => m.Ward, c => c.MapFrom(s => s.Ward.Name))
                .ForMember(m => m.Producer, c => c.MapFrom(s => s.Producer.Name));

            CreateMap<Ward, WardDto>();
            CreateMap<Producer, ProducerDto>();
            CreateMap<Inspection, InspectionDto>();

            CreateMap<CreateDeviceDto, Device>();

            CreateMap<CreateInspectionDto, Inspection>();
        }
    }
}
