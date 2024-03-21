using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ListServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();


            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<AboutListDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();


            CreateMap<TestimonialListDto, Testimonial>().ReverseMap();


            CreateMap<StaffListDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();

            CreateMap<ListBookingDto, Booking>().ReverseMap();

            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();


            CreateMap<GuestCreateDto, Guest>().ReverseMap();
            CreateMap<GuestListDto, Guest>().ReverseMap();
            CreateMap<GuestUpdateDto, Guest>().ReverseMap();


            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<ResultAppUserListDto, AppUser>().ReverseMap();
        }
    }
}
