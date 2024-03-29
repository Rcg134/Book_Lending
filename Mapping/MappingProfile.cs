﻿using Book_Lending.Context;
using AutoMapper;
using Book_Lending.DTO.Book;
using Book_Lending.Models.Book;


namespace Book_Lending.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserUpdateDTO, User>();
    }

}

