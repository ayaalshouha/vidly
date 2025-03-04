using AutoMapper;
using vidly.DTOs;
using vidly.Models;

namespace vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
    
            //Domain to DTO
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<Customer, CustomerDTO>() ;
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>() ;
        

            //DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

        }
    
    
    
    }
}