using AutoMapper; 
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs; 

namespace TekhnelogosInterviewProject.WebApi.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Personal, PersonalDto>();
            CreateMap<PersonalDto, Personal>();

            CreateMap<Personal, PersonalWithRoleDto>();
            CreateMap<PersonalWithRoleDto, Personal>();

            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoDto, Cargo>();

            CreateMap<Cargo, CargoWithCustAndPerDto>();
            CreateMap<CargoWithCustAndPerDto, Cargo>();
        }
    }
}
