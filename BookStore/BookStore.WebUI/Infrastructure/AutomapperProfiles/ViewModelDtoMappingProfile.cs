using BookStore.Business.Dto;
using BookStore.WebUI.Models;
using AutoMapper;

namespace BookStore.WebUI.Infrastructure.AutomapperProfiles
{
    public class ViewModelDtoMappingProfile : Profile
    {
        public ViewModelDtoMappingProfile() 
        {
            CreateMap<AuthorViewModel, AuthorDto>();
            CreateMap<BookViewModel, BookDto>();
        }
    }
}