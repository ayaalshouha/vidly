using AutoMapper;
using vidly.DTOs;
using vidly.Models;

namespace vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            Mapper.CreateMap<Customer, CustomerDTO>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Movie, MovieDTO>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<MovieDTO, Movie>();
        }
    }
}