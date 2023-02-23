
using Hotel.DatabaseContext;
using HotelApp.Data.Repositories;
using HotelApp.Models;
using HotelApp.Models.RequestModels;
using HotelApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services;

public class DataService : IDataService
{
    private readonly ApplicationDbContext _db;
    private readonly IUserRepository _userRepository;
    
    public DataService(ApplicationDbContext context, IUserRepository userRepository) 
    { 
        _db = context;
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<Room>> GetRoomList()
    {
        return await _db.Room.ToListAsync();
    }

    public ICollection<Booking> GetBookingList()
    {
        return  _db.Booking.ToList();
    }
    
    public async Task<IEnumerable<User>> GetUserList()
    {
        return await _db.User.ToListAsync();
    }

    public async Task<Room> GetRoom(int id)
    {
        return await _db.Room.FindAsync(id);
    }

    public async Task<Booking> GetBooking(int id)
    {
        return await _db.Booking.FindAsync(id);
    }

    public async Task<User> GetUser(int id)
    {
        return await _db.User.FindAsync(id);
    }
    
    public async Task<User> Login(LoginRequestModel user)
    {
        var existingUser =  _db.User.FirstOrDefault(m => m.UserEmail == user.Username && m.UserPassword == user.Password);

        if (existingUser == null)
        {
            return null;
        }
        return existingUser;
    }

    public async Task<Room> CreateRoom(Room room)
    {

    
        
        // _db.Booking.Where(p => p.Room.RoomId == room.RoomId)
        
        _db.Room.Add(room);
        await _db.SaveChangesAsync();

        return room;
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {

        // Booking test = new Booking();
        //
        //
        // test.Room.RoomId = booking.Room.RoomId;
        // test.User.UserId = booking.User.UserId;
        // test.DateIn= booking.DateIn;
        // test.DateOut = booking.DateOut;
        _db.Booking.Add(booking);
        await _db.SaveChangesAsync();

        return booking;
    }

    public async Task<UserViewModel> CreateUser(RegisterUserRequestModel model)
    {
        var existingUser = _userRepository.GetByEmail(model.UserEmail);

        var newUser = new User
        {
            // UserId = Guid.NewGuid(),
            UserId = 1,
            UserEmail = model.UserEmail,
            UserPassword = model.UserPassword
        };
        
        if (existingUser != null)
        {
            return null;
        }
        
        _userRepository.Add(newUser); 

        var viewModel = new UserViewModel()
        {
            UserId = newUser.UserId,
            UserEmail = newUser.UserEmail
        };

        return viewModel;
    }

    public async Task UpdateRoom(Room room)
    {

        _db.Entry(room).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task UpdateBooking(Booking booking)
    {
        _db.Entry(booking).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _db.Entry(user).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteRoom(int id)
    {
      var deleteRoom = await   _db.Room.FindAsync(id);
      _db.Room.Remove(deleteRoom);
      await _db.SaveChangesAsync();
    }

    public async Task DeleteBooking(int id)
    {
        var deleteBooking = await   _db.Booking.FindAsync(id);
        _db.Booking.Remove(deleteBooking);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var deleteUser = await   _db.User.FindAsync(id);
        _db.User.Remove(deleteUser);
        await _db.SaveChangesAsync();
    }

    
}