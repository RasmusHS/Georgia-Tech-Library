using AutoMapper;
using GTL.Application.DTO.Book.Query;
using GTL.Application.DTO.BookBorrowerings.Query;
using GTL.Application.DTO.BookCatalog.Query;
using GTL.Application.DTO.Member.Query;
using GTL.Domain.Models;

namespace GTL.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<, >().ReverseMap();
            CreateMap<Book, QueryBookDto>().ReverseMap();
            CreateMap<BookBorrowings, QueryBookBorrowingsDto>().ReverseMap();
            CreateMap<BookCatalog, QueryBookCatalogDto>().ReverseMap();
            CreateMap<Member, QueryMemberDto>().ReverseMap();
        }
    }
}
