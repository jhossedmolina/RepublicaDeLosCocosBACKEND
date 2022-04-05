using AutoMapper;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaDeLosCocos.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Surgery, SurgeryDTO>().ReverseMap();
        }
    }
}
