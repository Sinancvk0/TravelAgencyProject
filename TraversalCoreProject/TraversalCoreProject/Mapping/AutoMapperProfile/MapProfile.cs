using AutoMapper;
using DTOLayer.DTOs.AnnouscementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AddAnnouscementDto, Announcement>();
            CreateMap<Announcement,AddAnnouscementDto>();

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser,AppUserLoginDTOs>();

            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<AnnounscementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnounscementUpdateDto>();


        }
    }
}
