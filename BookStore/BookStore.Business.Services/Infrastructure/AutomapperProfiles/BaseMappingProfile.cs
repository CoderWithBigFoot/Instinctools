using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
