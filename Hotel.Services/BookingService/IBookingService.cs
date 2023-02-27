using HotelApp.Models;
using HotelApp.Models.DTO;

namespace Hotel.Services.BookingService;

public interface IBookingService
{
    
    public  Task<IEnumerable<Booking>> GetBookingList();
    
    public  Task<Booking> GetBookingByUserId(Guid id);
    
    
    public  Task<Booking> CreateBooking(Guid userId ,Guid roomId,BookingDto model);
    
    public  void UpdateBooking(Booking model);
    
    public  void DeleteBooking(Guid id);
}