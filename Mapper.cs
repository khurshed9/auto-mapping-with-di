using auto_mapper_testing.DTOs;
using AutoMapper;

public class Mapper:Profile
{
    public Mapper()
    {
        CreateMap<User, ReadUserDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();
        CreateMap<User, CreateUserDTO>().ReverseMap();
    }
}