using AutoMapper;
using GTL.Application.DTO.Acquisitions.Query;
using GTL.Application.DTO.Author.Query;
using GTL.Application.DTO.Item.Query;
using GTL.Application.DTO.ItemBorrowings.Query;
using GTL.Application.DTO.ItemCatalog.Query;
using GTL.Application.DTO.Member.Query;
using GTL.Application.DTO.ReserveItem.Query;
using GTL.Domain.Models;

namespace GTL.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<, >().ReverseMap();
            CreateMap<ItemEntity, QueryItemDto>().ReverseMap();
            CreateMap<ItemBorrowingsEntity, QueryItemBorrowingsDto>().ReverseMap();
            CreateMap<ItemCatalogEntity, QueryItemCatalogDto>().ReverseMap();
            CreateMap<MemberEntity, QueryMemberDto>().ReverseMap();
            CreateMap<AuthorEntity, QueryAuthorDto>().ReverseMap();
            CreateMap<AcquisitionEntity, QueryAcquisitionDto>().ReverseMap();
            CreateMap<ReserveItemEntity, QueryReservationsDto>().ReverseMap();
        }
    }
}
