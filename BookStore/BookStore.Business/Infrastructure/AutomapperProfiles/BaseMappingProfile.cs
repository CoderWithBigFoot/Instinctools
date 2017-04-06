using BookStore.Business.Dto;
using BookStore.Data.Entities;
using AutoMapper;

namespace BookStore.Business.Infrastructure.AutomapperProfiles
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
