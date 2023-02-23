using AutoMapper;
using HotelApp.Models.DTO;


namespace HotelApp.Models.Helper;

public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        CreateMap<Booking,BookingDto>();
    }
}