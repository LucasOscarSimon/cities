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
            CreateMap<Citizen, AuthenticatedCitizenDto>().ForMember(c => c.City, m => m.MapFrom(c => c.City.Name)).ReverseMap();
            CreateMap<Citizen, CitizenWithoutIdDto>().ReverseMap();
            CreateMap<Citizen, CitizenWithoutIdForCreateDto>().ReverseMap();
            CreateMap<City, CityDto>().ForMember(c => c.State, m => m.MapFrom(c => c.State.Name)).ReverseMap();
            CreateMap<CityExtended, CityDto>().ForMember(c => c.State, m => m.MapFrom(c => c.State.Name)).ReverseMap();
            CreateMap<City, CityWithoutId>().ReverseMap();
            CreateMap<City, CityWithoutIdForCreateDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<State, StateWithoutId>().ReverseMap();
            CreateMap<State, StateWithoutIdForCreateDto>().ReverseMap();
            CreateMap<User, AuthenticatedDto>().ReverseMap();
            CreateMap<User, AuthenticateDto>().ReverseMap();
            CreateMap<User, UserWithoutIdDto>().ReverseMap();
            CreateMap<User, UserWithoutIdForCreateDto>().ReverseMap();
            CreateMap<Citizen, UserWithoutIdForCreateDto>().ForMember(c => c.CityId, m => m.MapFrom(c => c.CityId)).ReverseMap();
        }
    }
}
