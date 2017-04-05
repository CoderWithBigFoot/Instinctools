using System;
using BookStore.Business.Dto;
using BookStore.Data.EntityFramework.Entities;
using AutoMapper;

namespace BookStore.Business.Services.Infrastructure.AutomapperProfiles
{
    public class BaseMappingProfile : Profile
    {
        public BaseMappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Func<AuthorDto, bool>, Func<Author, bool>>();
            
        }
    }
}
