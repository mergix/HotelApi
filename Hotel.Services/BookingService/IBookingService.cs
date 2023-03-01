using HotelApp.Models;
using HotelApp.Models.DTO;
using HotelApp.Models.ViewModels;

namespace Hotel.Services.BookingService;

public interface IBookingService
{
    
    public  Task<IEnumerable<Booking>> GetBookingList();
    
    public  Task<IEnumerable<Booking>> GetBookingListByUserId(Guid id);
    
    public  Task<Booking> GetBookingByUserId(Guid id);
    
    
    public  Task<BookingViewModel> CreateBooking(Guid userId ,Guid roomId,BookingDto model);
    
    public  void UpdateBooking(Booking model);
    
    public  void DeleteBooking(Guid id);
}