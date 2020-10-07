using AutoMapper;
using BusinessLayer.Dtos;
using DataAccess.Entity;

namespace BusinessLayer.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemVendorDto, ItemVendor>();
            CreateMap<ItemVendor, ItemVendorDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<Item, ItemDto>();
            CreateMap<HospitalDto, Hospital>();
            CreateMap<Hospital, HospitalDto>();
            CreateMap<PharmacyDto, Pharmacy>();
            CreateMap<Pharmacy, PharmacyDto>();
            CreateMap<PharmacyInventoryDto, PharmacyInventory>();
            CreateMap<PharmacyInventory, PharmacyInventoryDto>();
        }
    }
}
