using AutoMapper;
using Fasade.DTO;
using Fasade.Models;

namespace TBC_API.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<PersonDTO, PersonModel>().ReverseMap();
            CreateMap<CityDTO, CityModel>().ReverseMap();
            CreateMap<RelatedPersonDTO, RelatedPersonModel>().ReverseMap();
            CreateMap<UserDTO, UserModel>().ReverseMap();
        }
    }
}
