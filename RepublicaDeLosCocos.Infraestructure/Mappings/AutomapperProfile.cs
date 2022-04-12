using AutoMapper;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;

namespace RepublicaDeLosCocos.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Surgery, SurgeryDTO>().ReverseMap();
            CreateMap<AssignPatient, AssignPatientDTO>().ReverseMap();
            CreateMap<PatientInCare, PatientInCareDTO>().ReverseMap();
            CreateMap<UnrecoveredPatient, UnrecoveredPatientDTO>().ReverseMap();
        }
    }
}
