using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;

using DTOLayer.DTOs.AnnouscementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BussinessLayer.Container
{
    public static class ExtensionsDb
    {
        public static void ContainerDependencies(IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IExcelService, ExcelManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncement>();

     




        }

        public static void CustomerValidator( this IServiceCollection services)
        {

            services.AddTransient<IValidator<AddAnnouscementDto>, AnnouscementValidator>();


        }
    }
}
