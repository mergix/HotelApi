using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.DTO;
using HotelApp.Models.RequestModels;
using HotelApp.Models.ViewModels;

namespace Hotel.Services.BookingService;

public class BookingService :IBookingService
{

    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;
    
    public BookingService(IBookingRepository bookingRepository,IRoomRepository roomRepository,IUserRepository userRepository) 
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }


    public async Task<IEnumerable<Booking>> GetBookingList()
    {
        return _bookingRepository.GetAll();
    }

    public async Task<IEnumerable<Booking>> GetBookingListByUserId(Guid id)
    {
        
        return _bookingRepository.GetByUserId(id);
    }

    public async Task<Booking> GetBookingByUserId(Guid id)
    {
        return _bookingRepository.GetById(id);
    }

    public async Task<BookingViewModel> CreateBooking(Guid userId ,Guid roomId,BookingDto model)
    {
        var newBooking = new Booking()
        {
            BookingId = Guid.NewGuid(),
            DateIn = model.DateIn,
            DateOut = model.DateOut,
            User = _userRepository.GetById(userId),
            Room = _roomRepository.GetById(roomId),
            LastModified = DateTime.UtcNow
        };
        
        _bookingRepository.Add(newBooking);

        var viewModel = new BookingViewModel()
        {
            BookingId = newBooking.BookingId,
            DateIn = newBooking.DateIn,
            DateOut = newBooking.DateOut,
            Userid = newBooking.User.UserId,
            Roomid = newBooking.Room.RoomId
        };
        return viewModel;
    }

    public void UpdateBooking(Booking model)
    {
        _bookingRepository.Update(model);
    }

    public void DeleteBooking(Guid id)
    {
        _bookingRepository.Delete(id);
    }
}