using AutoMapper;
using ECommerce.Data.Domain;
using ECommerce.Schema;

namespace ECommerce.Operation.Mapper;
    public class MapperConfig : Profile
    {
    public MapperConfig()
    {

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
    }

   


    }

