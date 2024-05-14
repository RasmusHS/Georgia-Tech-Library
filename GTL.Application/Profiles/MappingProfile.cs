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
            CreateMap<BookEntity, QueryBookDto>().ReverseMap();
            CreateMap<BookBorrowingsEntity, QueryBookBorrowingsDto>().ReverseMap();
            CreateMap<BookCatalogEntity, QueryBookCatalogDto>().ReverseMap();
            CreateMap<MemberEntity, QueryMemberDto>().ReverseMap();
        }
    }
}
