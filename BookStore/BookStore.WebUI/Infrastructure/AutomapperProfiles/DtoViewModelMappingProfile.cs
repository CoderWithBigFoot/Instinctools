using BookStore.Business.Dto;
using BookStore.WebUI.Models;
using AutoMapper;


namespace BookStore.WebUI.Infrastructure.AutomapperProfiles
{
    public class DtoViewModelMappingProfile : Profile
    {
        public DtoViewModelMappingProfile()
        {
            CreateMap<AuthorDto, AuthorViewModel>();
            CreateMap<BookDto, BookViewModel>();
        }
    }
}