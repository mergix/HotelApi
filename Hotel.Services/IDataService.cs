using HotelApp.Models;

namespace Hotel.Services;

public interface IDataService
{
    Task<IEnumerable<Room>> GetRoomList();
    
   ICollection<Booking> GetBookingList();
    
    Task<IEnumerable<User>> GetUserList();

    Task<Room> GetRoom(int id);
    
    Task<Booking> GetBooking(int id);
    
    Task<User> GetUser(int id);
    
    Task<User> Login(User user);

    Task<Room> CreateRoom(Room room);
    
    Task<Booking> CreateBooking(Booking booking);
    
    Task<User> CreateUser(User user);

    Task UpdateRoom(Room room);
    
    Task UpdateBooking(Booking booking);
    
    Task UpdateUser(User user);

    Task DeleteRoom(int id);
    
    Task DeleteBooking(int id);
    
    Task DeleteUser(int id);
}