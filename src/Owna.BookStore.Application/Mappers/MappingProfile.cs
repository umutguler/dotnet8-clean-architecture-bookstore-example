using AutoMapper;
using Owna.BookStore.Application.Dtos;
using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<Book, BookDto>()
                .ForMember(dto => dto.Authors, opt => opt.MapFrom(src => src.Authors));
            CreateMap<BookDto, Book>()
                .ForMember(entity => entity.Authors, opt => opt.MapFrom(src => src.Authors));
        }
    }
}
