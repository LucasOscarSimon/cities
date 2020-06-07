using Entities.DataTransferObjects;
using Entities.Models;

namespace Cities.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Citizen, CitizenDto>().ForMember(c => c.City, m=>m.MapFrom(c => c.City.Name)).ReverseMap();

            CreateMap<Citizen, CitizenWithoutIdDto>().ReverseMap();
            CreateMap<Citizen, CitizenWithoutIdForCreateDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CityWithoutId>().ReverseMap();
            CreateMap<City, CityWithoutIdForCreateDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            // CreateMap<Citizen, CitizenDto>().ForMember(c => c.City, m => m.MapFrom(c => c)).ReverseMap();
        }
    }
}
