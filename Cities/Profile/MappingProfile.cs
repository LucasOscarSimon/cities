using Entities.DataTransferObjects;
using Entities.ExtendedModels;
using Entities.Models;

namespace Cities.Profile
{
    /// <summary>
    /// Automapper profile
    /// </summary>
    public class MappingProfile : AutoMapper.Profile
    {
        /// <summary>
        /// All mapped classes go inside this method
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Citizen, CitizenDto>().ForMember(c => c.City, m=>m.MapFrom(c => c.City.Name)).ReverseMap();
            CreateMap<Citizen, CitizenWithoutIdDto>().ReverseMap();
            CreateMap<Citizen, CitizenWithoutIdForCreateDto>().ReverseMap();
            CreateMap<City, CityDto>().ForMember(c => c.State, m => m.MapFrom(c => c.State.Name)).ReverseMap();
            CreateMap<CityExtended, CityDto>().ForMember(c => c.State, m => m.MapFrom(c => c.State.Name)).ReverseMap();
            CreateMap<City, CityWithoutId>().ReverseMap();
            CreateMap<City, CityWithoutIdForCreateDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
        }
    }
}
