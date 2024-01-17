using Book_Lending.Context;
using AutoMapper;
using Book_Lending.DTO;
using Book_Lending.DTO.Book;
using Book_Lending.Models.Book;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
    }

}

