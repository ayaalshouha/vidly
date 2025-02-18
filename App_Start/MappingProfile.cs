using AutoMapper;
using vidly.DTOs;
using vidly.Models;

namespace vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}