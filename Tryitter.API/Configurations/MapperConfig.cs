using AutoMapper;
using Tryitter.API.Data;
using Tryitter.API.Models.Module;
using Tryitter.API.Models.Tweet;
using Tryitter.API.Models.User;

namespace Tryitter.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, GetUserDetailsDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<Module, ModuleDto>().ReverseMap();

            CreateMap<Tweet, CreateTweetDto>().ReverseMap();
            CreateMap<Tweet, GetTweetDto>().ReverseMap();
            CreateMap<Tweet, GetTweetDetailsDto>().ReverseMap();
            CreateMap<Tweet, UpdateTweetDto>().ReverseMap();            
        }
    }
}
